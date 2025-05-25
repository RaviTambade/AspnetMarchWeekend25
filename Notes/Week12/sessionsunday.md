# 🌩️ Cloud Infrastructure

### 🧠 “Let’s simplify the cloud…”

Think of **Cloud Infrastructure** as a **rented virtual IT environment** where companies no longer buy bulky servers or maintain physical networks. Instead, they **subscribe** to compute power, storage, and networking over the internet.

## 🧱 What Is Provided in Cloud Infrastructure?

### 1. **Compute**

* Virtual CPUs & RAM for running apps
* Used by your application for processing tasks

### 2. **Storage**

* Stores app binaries, media, user files, databases

### 3. **Networking**

* Allows internal communication (between services)
* Enables public access (e.g., websites, APIs)

## 🧰 Three Cloud Service Models

### 1️⃣ Infrastructure as a Service (IaaS)

> “Your team manages everything except the physical hardware.”

* Rent **Virtual Machines** (VMs)
* Full OS, middleware, and apps managed by your IT team
* Connect via **Remote Desktop (RDP)**, **SSH**, etc.
* Example: **AWS EC2**, **Azure VM**, **Google Compute Engine**

### 2️⃣ Platform as a Service (PaaS)

> “You focus on your code; the cloud manages the rest.”

* You deploy **your code & data**
* Cloud provider manages runtime, DB, scaling, and orchestration
* Use containers & orchestration tools (e.g., Kubernetes, Azure AKS, AWS ECS)
* Example: **Azure App Service**, **Google App Engine**, **Heroku**

### 3️⃣ Software as a Service (SaaS)

> “You just log in and use a fully built application.”

* No installation or server setup
* Pay-per-user subscription model
* Examples: **Microsoft 365**, **Google Workspace**, **Zoom**, **Salesforce**

## 🧪 Real-World Example: Microsoft 365

Your company:

* Subscribes to **Microsoft 365**
* Gets full office suite, SharePoint, Teams, Outlook, and more
* No need for internal IT to manage servers or infrastructure
* Documents, portals, communication — all managed in the cloud

> "You're just managing your business, not your infrastructure."


## 📦 Containers vs Virtual Machines

| Feature   | Virtual Machine (VM)         | Container (e.g., Docker)     |
| --------- | ---------------------------- | ---------------------------- |
| OS        | Full OS                      | Shares host OS kernel        |
| Size      | Heavy                        | Lightweight                  |
| Boot Time | Minutes                      | Seconds                      |
| Isolation | Strong                       | Strong but more efficient    |
| Use Case  | Full control & custom setups | Microservices, scalable apps |

**Orchestration Tools**:

* **Docker Compose**
* **Kubernetes**
* **Azure Kubernetes Services (AKS)**
* **AWS ECS / Fargate**

## 📦 Docker + DevOps Flow

1. 🧑‍💻 **Developer** writes code in Visual Studio / VS Code
2. 📁 Pushes to **GitHub / GitLab**
3. ⚙️ CI/CD pipeline builds **container images**
4. 🐳 Docker images pushed to **Docker Hub** or **Azure Container Registry**
5. 🚀 Images deployed to test/production using orchestrators
6. 📊 Logs monitored and containers auto-scaled

## 🗣️ Mentor's Advice:

> “Choose the cloud model based on your business maturity:
> Start with SaaS → Graduate to PaaS → Scale with IaaS.”

 

## **🚀 Cloud Deployment Workshop: From Local Machine to AWS Using .NET CLI and GitHub**

👨‍🏫 **Mentor’s Perspective**

*"Let me take you on a journey—a developer’s path from a simple `.NET CLI` command to deploying a cloud-ready ASP.NET Core app on AWS EC2."*

### 🛠️ **Local Development: Setting the Foundation**

"First, as a developer, I didn’t use Visual Studio this time. I wanted to keep it lightweight—so I used **VS Code** and the **.NET CLI** tool.

I ran:

```bash
dotnet new mvc -o CloudReadyApp
cd CloudReadyApp
dotnet build
```

✅ This generated a simple skeleton ASP.NET Core MVC project—ideal for cloud deployment.

I compiled the app and verified its working using:

```bash
dotnet run
```

🖥️ The application started locally on `localhost:507x`. I copied the link, tested it in Chrome, and voilà—it worked. But remember, this is **local**. No one else can access it.

### 🔁 **Version Control with Git**

"To get it cloud-ready, I followed standard version control practices:

```bash
git init
git add .
git commit -m "Cloud Ready App"
git push origin main
```

🚀 My code was now live on GitHub, under a well-organized structure: `Week12 → CloudReadyApp`.

### ☁️ **Preparing AWS Cloud Environment**

"Now came the real deal—**deployment to the cloud**. For that, we need infrastructure. I logged in to my **AWS Console** using my root credentials.

🔐 *Tip:* Always distinguish between **root account** (admin) and **user accounts** (developer access). In a team, give IAM users access to AWS resources while you (as an admin) maintain billing and control.

### 🧱 **Choosing the Right AWS Service: EC2**

In AWS:

* **EC2 (Elastic Compute Cloud)** = Virtual machine
* **S3** = Storage buckets
* **VPC** = Your own isolated cloud network

But for today, we focus on **EC2** to simulate a real production server.

### 🎯 **Deployment Plan: From GitHub to AWS EC2**

✅ Steps we'll follow:

1. Launch a **new EC2 instance** (Ubuntu or Windows based).

2. SSH into the instance.

3. Install **.NET SDK**, **Git**, and **Nginx** or **Apache** (for reverse proxy if needed).

4. Clone the GitHub repo:

   ```bash
   git clone https://github.com/ravitambade/aspnet-weekend25.git
   ```

5. Navigate to `Week12/CloudReadyApp` directory.

6. Build and run:

   ```bash
   dotnet build
   dotnet run
   ```

7. Test using **public IP** of EC2: `http://<your-ec2-public-ip>:<port>`

🔐 **Security Group Reminder**: Open port 5000 or whatever your app runs on, in EC2 security settings.

### 📦 **Why This Matters**

By practicing this flow, you:

* Understand infrastructure (EC2, SSH, ports, firewalls).
* Learn CLI-first development.
* Use **open-source tools** like Git, GitHub, VS Code.
* Build **cloud-native mindset**: develop, test locally, push to GitHub, deploy to cloud.

### 🌍 Final Thought

*"You don’t need a big team or enterprise tools to deploy to the cloud. Just your CLI, code, and clarity."*
  

 

### ✅ **Cloud Deployment & Remote Access Flow Explained by Mentor**

1. **🔧 Server Naming and OS Selection**

   * Server named: **TfL Assessment Server**
   * OS chosen: **Ubuntu (Free tier eligible)** — lightweight, open-source, and ideal for student environments.

2. **🚀 Launching EC2 Instance on AWS**

   * Chose Ubuntu version from AWS EC2 list.
   * Used AWS Free Tier eligibility for cost-effective experimentation.
   * Instance launched with default firewall (Security Group) allowing basic access.

3. **🔐 Remote Access Using PuTTY**

   * Key Pair Created: `WeekendMay2025.ppk`
   * Tool used: **PuTTY** for secure SSH access to Linux EC2 from Windows.
   * SSH Port 22 opened, key file loaded in PuTTY → Connected as user `ubuntu`.

4. **🖥️ Terminal Commands (Basic Linux Admin)**

   * Performed initial system update: `sudo apt update`
   * Checked for Git installation: `git --version`
   * Cloned a GitHub repository containing .NET Core project.
   * Located project folder, confirmed app presence using `ls`, `cd`, etc.

5. **⚙️ .NET SDK Troubleshooting**

   * Tried running project using: `dotnet run`
   * Error: .NET 9.0 SDK not available on the server.
   * Explored Microsoft’s documentation for .NET installation on Ubuntu.
   * Attempted `dotnet-install.sh` script method — encountered compatibility issue.
   * Realized Ubuntu version may not support .NET 9.0 SDK.

6. **🔁 Solution Plan**

   * Switch to installing **.NET 8.0 SDK**, which is stable and supported.
   * Adjust project `.csproj` or target framework if needed to downgrade from 9.0 to 8.0.

### 💡 **Mentor Advice to Students**

> "When deploying apps in real-world servers, you step into the shoes of a **DevOps/Cloud Engineer**, not just a developer. You should know how to access remote servers, configure environments, manage software packages, and debug real deployment issues. This is how you become *industry-ready.*"

## 🧠 **Case Study: From Localhost to Cloud — Debugging ASP.NET Core Deployment on AWS Ubuntu VM**

### 🎯 Goal:

Deploy a self-hosted **ASP.NET Core MVC application** from local machine to an **AWS Ubuntu EC2 instance**, accessible remotely over the internet.

### 🔍 **Problem Encountered:**

Application ran perfectly on the **local development machine**, but **failed to respond to remote client requests** after deploying to the Ubuntu server. Even though the project was published and hosted on Kestrel at port `5000` or `8000`, the browser showed:

> ❌ *“This site can’t be reached”*

### 🛠️ **Root Cause:**

By default, **Kestrel server** in .NET Core binds only to **localhost (127.0.0.1)**.
It doesn’t listen to **external/public IPs** unless explicitly configured.

### ✅ **Solution Applied (Step-by-Step):**

#### 1. **Verify Application Binding**

Update `appsettings.json` or use `Program.cs` to configure Kestrel to listen on all IP addresses:

```json
// In appsettings.json
"Kestrel": {
  "Endpoints": {
    "Http": {
      "Url": "http://0.0.0.0:5000"
    }
  }
}
```

OR via `Program.cs` (for minimal API)

```csharp
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000);
});
```

#### 2. **Ensure EC2 Security Group Allows Port Access**

Go to AWS EC2 → **Security Groups** → Inbound Rules →
Add a rule to allow:

* Protocol: **TCP**
* Port Range: **5000** (or whichever you're using)
* Source: **0.0.0.0/0** (or specific IPs)

#### 3. **Install .NET SDK on Ubuntu**

Install the correct .NET SDK that matches the project target:

```bash
# Example for .NET 8 SDK on Ubuntu
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-sdk-8.0
```

#### 4. **Publish and Run Application on Ubuntu**

```bash
cd your-app-folder
dotnet publish -c Release -o out
cd out
dotnet yourapp.dll
```

Ensure that it's binding on port 5000 and accessible from browser.

#### 5. **Access Application Remotely**

In browser:

```
http://<EC2-PUBLIC-IP>:5000
```

### 🧠 Mentor Insights & Learning Philosophy

🔹 *“In real-world deployment, it’s not just about writing code — it’s about managing environments, configuring servers, and debugging unknowns.”*

🔹 *“We assumed it would work like it did in .NET 7.0 — but version 8.0 requires explicit Kestrel config. Never take shortcuts in production.”*

🔹 *“The debugging mindset is not about memorizing steps but about exploring, reading, and logically applying knowledge.”*

🔹 *“Generative AI tools, official docs, and forums can help — but real understanding comes when you get stuck and find your way out.”*

### ✅ **Skills Demonstrated in This Live Workshop**

* Git commands: `git add`, `git commit`, `git push`, `git pull`
* Linux terminal basics (`cd`, `ls`, `nano`)
* .NET SDK installation and version mismatch handling
* Kestrel configuration
* AWS EC2 management (firewall rules, SSH using PuTTY)
* Real-time problem-solving under pressure
* Patience + Focus + Logical Thinking + Curiosity

 
### 🔄 Next Step: Cloud-Ready Deployment

> **This deployment was done on a VM manually.**
>
> To make your app **cloud-ready**, learn to:
>
> * Use **Docker** containers
> * Create **CI/CD pipelines**
> * Host via **Elastic Beanstalk**, **Azure App Service**, or **Kubernetes**
 
# From Coder to Cloud-Savvy Solution Builder

“Let me take you all back to a moment — not too long ago.

It was a quiet Saturday morning, and I had just stepped into the lab with a batch of fresh minds — developers in the making. The goal was simple: **deploy an ASP.NET Core app to the cloud**.

At 10:30 AM sharp, we launched our **first EC2 instance** on AWS. There was a buzz in the room — excitement, nervousness, and curiosity.

By 12:30 PM, we had:
* Created and configured a virtual machine
* Deployed **ASP.NET Core and Node.js apps**
* Tested remote access from various devices

Success. But then… I paused.

> “Team,” I asked, “what’s going to happen if we leave this instance running for the rest of the day — even though our work is done?”

One student cautiously replied, “We’ll still be charged?”

**Exactly.**

### 💸 **The Forgotten Meter**

You see, cloud isn’t magic — it’s **metered**.

It’s like leaving your air conditioner running at home when you go on vacation. The comfort’s gone, but the bill keeps rising.

> I told them, “This is your first lesson in **DevOps thinking** — manage your cloud like you manage your electricity.”

We opened the EC2 dashboard. I showed them how to:

* **Stop the instance** — like shutting a laptop
* **Terminate it** — like dismantling it completely

We stopped the instance. A few seconds later, its state changed to “stopped.”

“See that?” I smiled. “That’s not just clicking a button — that’s being a **responsible cloud developer**.”

### 🧭 **The Real Deployment Journey**

Now I leaned back and told them a little story from my own experience:

> “In my first job, we used to copy-paste code files onto USB drives to deploy on staging servers!”

They laughed. But then I pointed at the whiteboard:

> “Today, here’s how we do it like professionals:”

1. Code locally
2. Push to **GitHub**
3. Pull it on any machine — a physical server, a VM, or a cloud instance
4. Install required SDKs
5. Run and test

“This flow,” I said, “is what lets developers **work from anywhere**, and deploy **everywhere**. GitHub becomes your **passport** to move code across borders.”

### 🧠 **DevOps Thinking: Becoming More Than a Coder**

“You know, I’ve seen hundreds of engineers — brilliant at syntax, fast at writing code. But only a few stand out.

Why?

Because they **think beyond the code.**
They understand:

* Servers need to be configured
* Apps need to be monitored
* Resources need to be optimized
* Downtime must be avoided

This is where **Dev meets Ops**.

> DevOps isn’t a job title. It’s a mindset.

I paused and wrote on the board:

**Dev = Code + Build + Test**
**Ops = Deploy + Monitor + Manage**

If you’re doing both — even at a small scale — you’re already a **DevOps developer**.”


### 🖥️ **Hosting .NET Apps on IIS: The Hidden Bridge**

I pulled up a real project folder.

> “Let’s talk about IIS now — especially if you’re deploying .NET Core on a Windows Server.”

I explained how older .NET Framework apps depended entirely on IIS.

“But .NET Core,” I said, “is different. It uses **Kestrel** as the actual web server. IIS just plays the role of a **gatekeeper** — a reverse proxy.”

Then I walked them through:

* Installing the .NET Hosting Bundle
* Publishing using `dotnet publish`
* Creating a site in IIS
* Configuring `web.config` as the **bridge**

> “IIS doesn’t run the code. It hands over the request to Kestrel quietly — like a butler passing a message to the chef.”

They smiled. I could see they got it.

### 🔐 **Real Apps Need More Than UI**

I looked around and asked:

> “Now tell me — if we build an eCommerce app, what else will we need?”

They shouted:

“Login!”
“Roles!”
“Product management!”
“Secure payments!”

Exactly.

I drew a sketch of a microservice architecture:

* Auth Service (JWT Tokens)
* Product Service
* Order Service
* Payment Service

Each small, focused, and independently deployable.

> “This is what you’ll see in real-world enterprise apps. And these services? They talk to each other — via **REST APIs or gRPC**.”

We then discussed **Docker**, containers, and how we could package these microservices to run anywhere — from AWS to Azure, even local Docker Desktop.

### 🎯 **Lesson of the Day: Build Systems, Not Just Apps**

> “Cloud,” I told them, “isn’t about EC2 or Azure alone. It’s about a new way of thinking.”

It’s about:

* Knowing how to **deploy on Linux and Windows**
* Managing **IIS, Kestrel, firewall ports**
* Configuring **environment variables**
* Tracking usage and **stopping unused resources**
* Using **Git** not just to store code, but to drive workflows

### 🔄 **What’s Coming Next?**

> “Next week,” I smiled, “we’re building something together.”

Here’s what we’ll do:

* A **secure ASP.NET Core app**
* With **JWT authentication**
* Role-based access for Admin, Manager, and User
* Add **WebSocket** for real-time updates
* Implement **Gateway logic**
* Containerize it using **Docker**
* And deploy on cloud

By the end, they won’t just be students — they’ll be **cloud-ready engineers**.

### 💬 Mentor’s Final Thought:

> “You’re not here to be just a programmer. You’re here to **build, manage, and deliver value.**

So ask yourself:
*Are you just writing code?
Or are you building solutions that live, run, scale, and grow in the real world?*

Because when companies look for someone who can *‘build and run’* — not just *‘code and push’* — that’s when you’ll stand out.”