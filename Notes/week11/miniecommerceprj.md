# Simulating the core of an eCommerce system 
 
## 🧪 Project Title: **Mini eCommerce System - Order Flow Simulation**

### Introduction
This case study presents a simulated eCommerce backend system designed to demonstrate how modern communication technologies—REST APIs, gRPC, RabbitMQ, and WebSockets—enable seamless interoperability among distributed microservices. The system mimics a real-world order workflow where a customer places an order via a RESTful interface, triggering synchronous backend operations through gRPC for inventory and payment validation. Upon successful processing, asynchronous communication via RabbitMQ decouples the order fulfillment and shipping processes. Real-time updates are pushed to the client through WebSockets, showcasing an end-to-end event-driven architecture. This project illustrates how combining synchronous and asynchronous communication patterns ensures responsiveness, scalability, and loose coupling in modern software systems.

 
### 🎯 **Goal**

Build a simplified backend architecture where:

* A user places an order via a REST/gRPC API.
* The `OrderService` interacts synchronously with `InventoryService` and `PaymentService` via gRPC.
* The `OrderService` sends an async message to RabbitMQ.
* A `ShippingService` consumes the message and logs shipping status.

---

## 📦 **Services & Components**

| Service            | Communication     | Responsibilities                                                                  |
| ------------------ | ----------------- | --------------------------------------------------------------------------------- |
| `OrderService`     | REST + gRPC       | Accepts orders, calls inventory & payment services, publishes message to RabbitMQ |
| `InventoryService` | gRPC              | Checks product availability                                                       |
| `PaymentService`   | gRPC              | Simulates payment                                                                 |
| `ShippingService`  | RabbitMQ Consumer | Consumes messages and processes shipment                                          |

---

## 🛠️ Step-by-Step Implementation Plan

### 1. **Setup Projects**

Create a solution with these projects:

```
MiniECommerce/
│
├── OrderService/         (ASP.NET Core REST + gRPC)
├── InventoryService/     (gRPC only)
├── PaymentService/       (gRPC only)
├── ShippingService/      (Console app - RabbitMQ Consumer)
└── Protos/               (Shared gRPC proto files)
```

---

### 2. **Define gRPC Protos**

`Protos/order.proto` example:

```proto
syntax = "proto3";

service Inventory {
  rpc CheckStock (StockRequest) returns (StockReply);
}

message StockRequest {
  string productId = 1;
  int32 quantity = 2;
}

message StockReply {
  bool isAvailable = 1;
}
```

(Define similar proto for Payment)

---

### 3. **Implement Services**

#### ✅ InventoryService & PaymentService

* Console or ASP.NET Core gRPC servers
* Implement gRPC methods with mock logic (e.g., always return success)

#### ✅ OrderService

* Expose REST or gRPC endpoint `/placeOrder`
* On order:

  * Call InventoryService.CheckStock
  * Call PaymentService.ProcessPayment
  * If both succeed, publish order info to RabbitMQ

#### ✅ ShippingService

* Connect to RabbitMQ queue
* On message, simulate "Shipping started for OrderId: 123"
* Log to console or write to file

---

### 4. **Set Up RabbitMQ**

* Use Docker:

```bash
docker run -d --hostname rabbit --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

* RabbitMQ Dashboard: [http://localhost:15672](http://localhost:15672) (user: `guest`, pass: `guest`)

---

### 5. **Run and Test**

1. Start all services.
2. Call `/placeOrder` via Postman or browser.
3. Watch RabbitMQ publish, and ShippingService consume and log shipping confirmation.

---

## 🎁 Bonus Ideas

* Add retry logic in ShippingService.
* Add UI or Swagger for OrderService.
* Add a central logging service using another queue.

---

Let's build a **mini eCommerce backend simulation** that integrates **REST API**, **gRPC**, **RabbitMQ**, and **WebSockets** to demonstrate real-world communication patterns between services.

---

## 🚀 Project Title:

**SmartCart – Simulated eCommerce Backend with REST, gRPC, RabbitMQ, WebSockets**

---

## 🧩 System Overview

| Component                | Communication      | Description                                      |
| ------------------------ | ------------------ | ------------------------------------------------ |
| 🛍️ `Frontend (UI)`      | REST + WebSocket   | Sends order requests and receives live status    |
| 📦 `OrderService`        | REST API           | Accepts order, initiates workflows               |
| 🏪 `InventoryService`    | gRPC               | Checks and reserves stock                        |
| 💳 `PaymentService`      | gRPC               | Processes mock payments                          |
| 📧 `NotificationService` | RabbitMQ Publisher | Sends order events to message queue              |
| 🚚 `ShippingService`     | RabbitMQ Consumer  | Handles delivery processing                      |
| 📢 `StatusHub`           | WebSocket Server   | Broadcasts live updates to client (order status) |

---

## 🎯 Technologies

* **.NET Core 9 / 8** (or Node.js with NestJS/Express + gRPC libraries)
* **gRPC** (backend-to-backend communication)
* **RabbitMQ** (asynchronous messaging)
* **WebSocket (SignalR or native)** (real-time status updates)
* **Docker Compose** (for running RabbitMQ and all services)

---

## ⚙️ Workflow

```plaintext
[Frontend User]
   │
   ├─> POST /placeOrder ───────────▶ [OrderService] ─┬─> gRPC ▶ [InventoryService]
   │                                                ├─> gRPC ▶ [PaymentService]
   │                                                └─> Publish to ▶ [RabbitMQ Queue]
   │
   ◀──────────────── WebSocket (live updates) ◀────── [StatusHub] ◀──── [ShippingService]
```

---

## 🛠 Project Structure

```plaintext
SmartCart/
├── OrderService/           → REST API + gRPC client + RabbitMQ publisher
├── InventoryService/       → gRPC server (stock check)
├── PaymentService/         → gRPC server (mock payment)
├── NotificationService/    → Publishes order events to queue
├── ShippingService/        → RabbitMQ consumer (process orders)
├── StatusHub/              → WebSocket server (SignalR)
├── Protos/                 → Shared gRPC proto files
├── UI/                     → Simple HTML + JS frontend using REST & WebSocket
└── docker-compose.yml      → RabbitMQ + services
```

---

## 📘 Feature Highlights

### 🔹 REST API (OrderService)

* Endpoint: `POST /placeOrder`
* Payload: `{ userId, items[], address }`
* Workflow:

  1. Validate order
  2. Call `InventoryService` via gRPC
  3. Call `PaymentService` via gRPC
  4. If successful, publish event to RabbitMQ
  5. Notify UI via WebSocket

### 🔹 gRPC Services

* `InventoryService.CheckAvailability(productId, quantity)`
* `PaymentService.ProcessPayment(userId, amount)`

### 🔹 RabbitMQ Messaging

* `OrderPlaced` message → queue: `orders`
* Consumed by `ShippingService`, triggers simulated shipment
* Shipping publishes `OrderShipped` event → relayed to `StatusHub`

### 🔹 WebSocket (SignalR or native)

* Browser client connects to `StatusHub`
* Receives live updates like:

  ```json
  {
    "orderId": "ORD123",
    "status": "Payment Confirmed"
  }
  ```

---

## 🧪 Sample Demo Flow

1. User places order via UI (REST).
2. `OrderService` processes it using gRPC.
3. Pushes status to RabbitMQ and notifies UI via WebSocket.
4. `ShippingService` simulates shipping and sends another update via WebSocket.

---

## 📦 Sample Technologies

| Tech      | .NET Option                    | Node.js Option                  |
| --------- | ------------------------------ | ------------------------------- |
| REST API  | ASP.NET Core Web API           | Express.js                      |
| gRPC      | .NET gRPC templates            | `@grpc/grpc-js`, `proto-loader` |
| RabbitMQ  | `RabbitMQ.Client` NuGet        | `amqplib`                       |
| WebSocket | SignalR / WebSocket middleware | `ws` / `socket.io`              |

---



