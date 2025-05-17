
 
 # Interoperability-simple gRPC service in .NET Core** and a **Node.js client** .

---

## 🔧 1. Create gRPC Server in .NET Core

### ✅ Step 1: Create the .NET gRPC project

```bash
dotnet new grpc -o GrpcGreeterServer
cd GrpcGreeterServer
```

### ✅ Step 2: Check the proto file

`Protos/greet.proto` should exist. It usually looks like this:

```proto
syntax = "proto3";

option csharp_namespace = "GrpcGreeterServer";

package greet;

service Greeter {
  rpc SayHello (HelloRequest) returns (HelloReply);
}

message HelloRequest {
  string name = 1;
}

message HelloReply {
  string message = 1;
}
```

### ✅ Step 3: Implement the gRPC service

Edit `Services/GreeterService.cs`:

```csharp
public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
```

### ✅ Step 4: Run the gRPC Server

```bash
dotnet run
```

By default, it runs at:
🟢 `https://localhost:5001`

---

## 🌐 2. Create Node.js gRPC Client

### ✅ Step 1: Setup Node.js project

```bash
mkdir grpc-node-client
cd grpc-node-client
npm init -y
npm install @grpc/grpc-js @grpc/proto-loader
```

### ✅ Step 2: Copy the `greet.proto` file

Copy the same `greet.proto` file from `.NET` project’s `Protos/` folder to the Node project root.

### ✅ Step 3: Create `client.js`

```js
const grpc = require('@grpc/grpc-js');
const protoLoader = require('@grpc/proto-loader');

const PROTO_PATH = __dirname + '/greet.proto';

// Load protobuf
const packageDefinition = protoLoader.loadSync(PROTO_PATH, {
  keepCase: true,
  longs: String,
  enums: String,
  defaults: true,
  oneofs: true
});
const greetProto = grpc.loadPackageDefinition(packageDefinition).greet;

// Create gRPC client
const client = new greetProto.Greeter('localhost:5001', grpc.credentials.createInsecure());

// Call the SayHello RPC
client.SayHello({ name: 'Ravi' }, (err, response) => {
  if (err) {
    console.error('Error:', err);
    return;
  }
  console.log('Greeting from server:', response.message);
});
```

> 🧠 **Note:** gRPC on `.NET` uses HTTPS by default. But Node client with `createInsecure()` uses **HTTP**. You need to either:

* Enable insecure gRPC in .NET for localhost, or
* Use certificates in Node.js client (advanced).

For testing, modify `.NET` server to allow insecure HTTP.

---

## ✅ Optional: Enable HTTP/2 insecure on .NET (for localhost testing)

Modify `appsettings.json`:

```json
{
  "Kestrel": {
    "Endpoints": {
      "Grpc": {
        "Url": "http://localhost:5001",
        "Protocols": "Http2"
      }
    }
  }
}
```

And modify `Program.cs` or `Startup.cs` accordingly.

---

## ✅ Run Everything

1. Start the .NET gRPC server:

```bash
cd GrpcGreeterServer
dotnet run
```

2. In a new terminal, run the Node.js client:

```bash
cd grpc-node-client
node client.js
```

✅ You should see:

```
Greeting from server: Hello Ravi
```

---

## 🚀 Summary

| Component       | Technology                  |
| --------------- | --------------------------- |
| gRPC Server     | .NET Core                   |
| gRPC Client     | Node.js                     |
| Protocol Format | Protocol Buffers (`.proto`) |

---
