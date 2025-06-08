## *"From Student to Deployment Engineer"*

### 🏁 Scene: Day 1 of Deployment Module

> 👨‍🏫 *"Good morning, team! Today, you’ll stop being 'just developers'. You’re stepping into the world of **Deployment Engineers** — the tech warriors who launch applications into the real world. Get ready for your first mission: Creating a virtual server, setting up IIS, and hosting your first ASP.NET app like a pro!"*

## 🌐 Step 1: Setting Up a Virtual Machine (Windows Server 2019 Datacenter)

🧭 *Mentor Note*: "A virtual machine is like building your own computer inside someone else’s data center — just without the physical headache."

### 🛠️ Setup Options:

* **Azure** (recommended for beginners — free credits)
* **VirtualBox or VMware** (for local practice)

### 🧱 Steps for Azure:

1. Go to [https://portal.azure.com](https://portal.azure.com)
2. Click **Create a Resource → Virtual Machine**
3. **Choose:**

   * **Image**: Windows Server 2019 Datacenter
   * **Size**: Standard B2s (sufficient for demos)
   * **Username & Password**: (Save it securely)
   * **Public IP**: Yes
4. **Networking**:

   * Select or create **NSG (Network Security Group)**
   * Open ports: **3389** (RDP), **80** (HTTP), **5005** (for Kestrel)

🚀 *"Click Create and grab some water — your personal server in the cloud is being born!"*

## 🔑 Step 2: Connect via Remote Desktop (RDP)

> *“Once your VM is ready, it's like having a remote control to your new machine. Think of it as teleporting into your server.”*

1. Click on **“Connect” → RDP** in Azure VM dashboard.
2. Use **Remote Desktop Connection** on your Windows machine:

   * IP Address
   * Username and Password

## 🏗️ Step 3: Install IIS (Internet Information Services)

📘 *Analogy*: *"IIS is like the receptionist of your office. When visitors come (via browser), IIS knows how to greet and serve your app properly."*

### Steps:

1. Open **Server Manager** on VM.
2. Click **Add Roles and Features**.
3. Choose:

   * **Role-based installation**
   * Select the local server
4. Under **Roles**:

   * Tick **Web Server (IIS)**
   * Under “Web Server → Application Development” tick:

     * ASP.NET 4.8
     * .NET Extensibility
     * ISAPI Extensions
     * ISAPI Filters
5. Complete installation.

🎓 *Mentor Wisdom*: “IIS is classic, still used in 70% of enterprise intranet apps. But in modern apps, we often use **Kestrel + reverse proxy** for speed and simplicity.”

## ⚙️ Step 4: Install .NET SDK and Hosting Bundle

📥 Go to [https://dotnet.microsoft.com](https://dotnet.microsoft.com/download) on the VM and download:

* **.NET SDK** (8.0 or 9.0)
* **ASP.NET Core Hosting Bundle** (for IIS support)

Run both installers → Restart server.

## 🔌 Step 5: Deploy Your ASP.NET Core App

### Option A: Run with **Kestrel** (Modern Way)

1. Copy your app to the VM (via Git, FTP, or zip upload)
2. Open PowerShell or Command Prompt:

```bash
cd C:\MyApp
dotnet run --urls "http://0.0.0.0:5005"
```

3. Open browser:

```bash
http://<public-ip>:5005
```

🛡️ **Don’t Forget**:

* Open port **5005** in Azure NSG
* Allow port 5005 in **Windows Defender Firewall**

### Option B: Host with **IIS** (Classic Way)

1. Publish app from Visual Studio:

   * Right-click project → Publish → Folder
2. Copy published folder to VM (e.g., `C:\inetpub\MyApp`)
3. In **IIS Manager**:

   * Add **New Site**
   * Point physical path to `C:\inetpub\MyApp`
   * Set Port: 80 or custom like 8080
4. Set correct app pool:

   * Use **No Managed Code** if .NET Core
   * Ensure **32-bit apps** are enabled if needed

🧪 Browse:

```bash
http://<public-ip>:80
```

## 🧠 Bonus: Make it Run as a Windows Service (Optional)

Use `nssm` or `sc` commands to register your `dotnet run` app as a background service for auto-restart and reliability.

## 🎓 Real-World Reflection

> *“This is how it starts. You build the app, deploy it to a server, open firewall, configure services, monitor usage — that’s full-stack in action.”*

## 📌 Assignment for Students

| Task           | Description                                        |
| -------------- | -------------------------------------------------- |
| ☁️ VM Creation | Set up a Windows Server 2019 VM (Azure or locally) |
| 🧱 IIS Setup   | Install IIS + ASP.NET Features                     |
| 🧩 App Hosting | Deploy a sample MVC app using `dotnet run` or IIS  |
| 🔐 Access App  | Make it accessible via public IP and custom port   |
| 📸 Screenshot  | Take 3 screenshots of successful deployment        |
| 📕 Report      | Document all steps in your DevOps notebook         |

## 💡 Final Mentor Message

> *"Don’t wait for the ‘DevOps Engineer’ title. Live it. Practice like a real engineer — deploy, troubleshoot, iterate. You’re now in control of not just writing code, but launching it into the world."*



## 🧭 Mentor Blueprint: "Be Both — Developer + DevOps Engineer"


### 🧑‍🏫 Mentor Opening Line:

> “In the real world, developers build apps. DevOps engineers make sure those apps are alive, accessible, secure, and scalable. But what if you could be both? You’d become unstoppable.”

### 💡 Part 1: Mindset Shift — Beyond Just Coding

#### 🧠 Teach This Philosophy:

| Developer Mindset       | DevOps Mindset                           |
| ----------------------- | ---------------------------------------- |
| Write code              | Deliver code safely                      |
| Focus on logic          | Focus on performance                     |
| Fix bugs                | Prevent downtime                         |
| Local machine runs fine | Server runs it 24/7                      |
| Uses `F5` to run        | Uses `systemctl`, `dotnet`, `pm2` to run |

🎯 *Mentor Message*: “Being a DevOps Engineer is not a separate job. It’s the part of the developer who **cares about what happens after the code leaves their laptop**.”



### ⚙️ Part 2: Hands-on Confidence Builders (Weekly Missions)

#### 🚀 **Developer Side Missions:**

* Build ASP.NET Core MVC & Web APIs
* Use `HttpClient`, handle API errors gracefully
* Implement custom middleware for logging/auth
* Create Unit Tests using xUnit
* Build frontend using Razor or minimal React

#### 🌐 **DevOps Side Missions:**

* Setup VM (Azure/AWS/Local)
* Install and configure IIS
* Host app using `dotnet run`, IIS, or Docker
* Configure firewall, open custom ports
* Monitor logs using Windows Event Viewer / `journalctl`
* Setup auto-restart with Windows service or `nssm`
* Write a basic PowerShell deployment script

### 🔄 Part 3: Role Rotation Challenge (Team-based)

> 🧪 *2 students as Developers, 2 as DevOps*
> 👷‍♂️ Developers write and publish the app
> 🛠️ DevOps deploys and makes it accessible over internet
> 🔁 Next week, rotate roles!

🎯 *This builds empathy*: Developers learn what breaks in production. DevOps learn to debug source code if needed.

### 🛡️ Part 4: Confidence Journal (Daily/Weekly)

Ask students to maintain a **“DevOps + Developer Journal”**, including:

* What I built this week
* What I deployed this week
* What went wrong and how I fixed it
* One command/script I learned
* One interview question I can now answer


### 🔥 Part 5: Mentor Wisdom Nuggets

Drop these in every session to inspire and build identity:

> 💬 “You deploy it, you own it.”
> 💬 “Your app is your responsibility — from localhost to production.”
> 💬 “You’re not waiting for a DevOps guy. You *are* the DevOps guy.”
> 💬 “Debugging in production is a skill, not a shame.”
> 💬 “You don’t fear the terminal — you control it.”


### 📚 Part 6: Confidence-Driven Curriculum

| Skill          | Dev Focus                | DevOps Focus                           |
| -------------- | ------------------------ | -------------------------------------- |
| Git            | Git clone, commit, merge | Git hooks, GitHub Actions              |
| .NET Core      | MVC, Web API             | Hosting bundle, configuration          |
| SQL            | Write stored procedures  | Setup SQL Server on VM                 |
| IIS            | Build to host            | Configure bindings, reverse proxy      |
| Kestrel        | Use in dev               | Expose to public with firewall configs |
| Logging        | Use Serilog/ILogger      | Analyze logs in logs folder            |
| Docker (later) | Write Dockerfile         | Build image, deploy container          |
| CI/CD          | Write tests              | Setup GitHub Actions / Jenkins         |

 

### 📍 Part 7: Weekly 5-Min Reflections

> 🧠 Ask students every Friday:

* What’s one thing you now understand better?
* What DevOps task scared you at first but you figured it out?
* What could go wrong if you skip this step in production?

 

### 🧰 Optional Bonus: Tools to Teach

| Tool                | Purpose                              |
| ------------------- | ------------------------------------ |
| Postman             | API Testing                          |
| GitHub Actions      | CI/CD pipelines                      |
| Azure/AWS           | VM, cloud deployment                 |
| Notepad++ / VS Code | Simple editing on server             |
| Wireshark / Fiddler | (Advanced) Understand network issues |

 

### 🏆 Final Realization: Student Becomes Engineer

> “When a student installs IIS, configures the firewall, deploys a Web API, and accesses it from their phone — something changes in their confidence. They stop doubting. They start owning.”

 
 