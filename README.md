### FullStack .NET Core App Weekend Training Notes

#### Overview of FullStack Development
- **FullStack**: A comprehensive development approach covering:
  - **UI Development**: Frontend development for user interfaces.
  - **App Development**: Backend application development.
  - **Backend Integration**: Connecting the backend to frontend and external systems.
  - **Testing**: Ensuring the application works as expected.
  - **Deployment**: Deploying applications to production.
  - **CI/CD Pipeline**: Automating integration and deployment in .NET Core solutions.

---

#### Phases of Software Development

##### 1. **Waterfall Model**:
   - Sequential design process.
   - Each phase must be completed before moving to the next.
   - Suitable for projects with well-defined requirements.

##### 2. **Incremental and Iterative Development**:
   - Iterations allow feedback and changes during development.
   - Useful for evolving requirements and frequent releases.

##### 3. **SDLC Practice in Product-Based and Service-Based Companies**:
   - **Product-based companies** follow an iterative approach for evolving products.
   - **Service-based companies** often use Agile methodologies to provide customized solutions.
   - **Agile Methodology** was introduced around the year 2000 to focus on flexibility and iterative progress.

##### 4. **Agile Methodology**:
   - Agile emphasizes flexibility, collaboration, and continuous delivery.
   - **Scrum Framework**:
     - Daily standup meetings.
     - **Product Owner** responsible for defining the product backlog.
     - The backlog consists of a **set of user stories**.
     - **Sprint Planning**: Project work is organized into short cycles (Sprints).
     - Each Sprint is typically **15-30 days**.

---

#### Types of Software Products

- **Windows Applications**:
  - Used in business offices and for staff management.
  
- **Web Applications**:
  - Web-based UI for branch offices, knowledge workers, franchises, vendors, and retail stores.

- **Mobile Applications**:
  - Mobile UI for various use cases with a focus on personalization, localization, and security.
  
- **Security Features**:
  - **Role-based Access Control** (RBAC).
  - **Personalization** and **Localization**.

---

#### Microsoft Libraries

- **FCL (Framework Class Libraries)**:
  - A collection of class libraries in `.dll` files.
  - Example Libraries:
    - `System.dll`
    - `System.Web.dll`
    - `System.Data.dll`
  - Contain **namespaces**, **classes**, **interfaces**, **structures**, **enums**, **events**, and **delegates**.

---

#### ASP.NET Framework

- **ASP.NET Web Forms**:
  - Pages like **default.aspx** and **default.aspx.cs**.
  - It is an object model with web forms, server controls, and master pages.
  - Webforms use elements like `<asp:TextBox>` for UI components.

- **ADO.NET**:
  - An object model for database interactions.
  - Examples: `OracleConnection`, `OracleCommand`, `OracleDataAdapter`.
  - Works with **DataReader** for fetching data.

- **ASP.NET (Until 2008)**:
  - Focused on building applications quickly using web forms.
  - Applications should be **lightweight**.
    - Avoid using bulky objects.
    - Avoid heavy page life cycles and generating large payloads.

- **Best Practices**:
  - Design patterns like **Observer**, **Singleton**, and **Class Factory**.
  
---

#### Evolution of ASP.NET Framework

- **2008: ASP.NET MVC**:
  - Introduced to improve web development using MVC (Model-View-Controller) architecture.
  - Incorporates best practices for building applications.
  - Provides design patterns for better maintainability.

- **2016: .NET Core + ASP.NET Core**:
  - Introduced **cross-platform** development.
  - Emphasis on **Cloud-based architectures** and adoption of **microservices**.

---

#### Cloud Architecture

- **Cloud**: "Pay-as-you-go" model for application and data hosting.
  - Data centers, servers, and applications are deployed in the cloud.
  
- **Service-Oriented Architecture (SOA)**:
  - Focus on building solutions using **loosely coupled** and **reusable** web services.
  - **Scalability** and **maintainability** are key features.

- **Monolithic vs. Microservices**:
  - Monolithic: All components in a single application.
  - Microservices: Independent, loosely coupled services, making applications easier to scale and maintain.

---

#### Project-Based Learning Approach

- **80% Hands-on Oriented**:
  - Learn by doing, understanding by debugging, and building confidence through practice.
  - Visualize using block diagrams and read documentation to collect information.

---

### FullStack .NET Core Development Topics

1. **Setting up .NET Core**:
   - Installing .NET Core SDK and Visual Studio Code.
   - Creating applications using the .NET CLI.
  
2. **MVC Architecture**:
   - Explore the structure of **Model-View-Controller (MVC)** architecture.
   - Integrating multiple layers of code for application development.

3. **Folder Structure**:
   - Understand the folder structure of a .NET application and the purpose of each folder (e.g., `Controllers`, `Views`, `Models`).

4. **Design Principles**:
   - **SOLID** (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion).
   - **DRY** (Don't Repeat Yourself).
   - **KISS** (Keep It Simple, Stupid).

5. **Design Patterns**:
   - **Structural**: Deals with object composition.
   - **Behavioral**: Deals with object communication.
   - **Creational**: Deals with object creation.

6. **Middleware Pipeline**:
   - How HTTP requests are handled in the application.
   - Using **middleware** to handle logging, security, and other concerns.

7. **Dependency Injection**:
   - Techniques to decouple components in a system for better testability and maintainability.

8. **Repository Pattern**:
   - A design pattern that abstracts data access logic for easier unit testing.

9. **Request-Response Life Cycle**:
   - Understanding how ASP.NET Core handles HTTP requests and generates responses.

10. **State Management**:
    - **Session**, **Cookies**, **Query String**, **Cache**, and **Redis Cache**.

11. **Database Connectivity**:
    - Basic ADO.NET and **Entity Framework Core** for ORM (Object Relational Mapping).
    - **Dapper**: A lightweight ORM.

12. **Authentication and Authorization**:
    - Different authentication methods: **LDAP**, **SSO**, **Active Directory**, **OAuth**, and **SAML**.

13. **Microservices Architecture**:
    - Building microservices, API Gateway, service integration, security, and communication between services.

14. **Integrating with JavaScript UI**:
    - Using frontend frameworks like **React**, **Angular**, and CSS libraries like **Bootstrap** and **Tailwind.css**.

---

#### .NET Core Application Creation Process

1. **Creating a Solution in Visual Studio**:
   - Create a new project, set up the **solution** structure, and organize **source code**.
   - Manage **resources** like images, videos, and localized content.
  
2. **Structure of Application**:
   - Understand the basic flow and architecture of an ASP.NET Core application.
   - Organize files and folders for scalability and maintainability.

---

### Conclusion

The training provides a comprehensive understanding of FullStack .NET Core development, from basic web application setup to advanced topics like microservices, middleware, authentication, and integrating with modern UI frameworks. Emphasis is placed on hands-on learning, understanding design patterns, and best practices to build scalable, maintainable, and secure applications.
