# Municipal Services Application

## Overview
This project is a **C# .NET Framework** desktop application designed to streamline municipal services for citizens in South Africa. It allows users to report issues, access local event announcements, and check the status of their service requests. 

### Features Implemented:
1. **Report Issues**: 
   - Citizens can report municipal issues like sanitation, road problems, and utility concerns.
   - Attachments and detailed descriptions can be added.
2. **Local Events and Announcements**: 
   - View upcoming local events and announcements.
   - Search for events based on categories like music, sports, and community events.
   - A recommendation engine suggests events based on user search patterns.
3. **Service Request Status**: 
   - View the status of submitted service requests.
   - Check related requests and their details.

---

## Technologies Used
- **C# .NET Framework (WPF)** for application logic.
- **XAML** for UI design.
- **Visual Studio 2022** as the IDE.
- **Advanced Data Structures** like BSTs and Graphs to manage service requests and their relationships.

---

## How to Compile and Run the Program

### Prerequisites
1. **Visual Studio 2022** (or later) with the **.NET Framework** installed.
2. **.NET Framework 4.7.2** (or later).

### Steps to Compile
1. Clone or download this repository to your local machine.
2. Open the solution file (`MunicipalServicesApp.sln`) in Visual Studio.
3. Build the solution by selecting **Build** > **Build Solution** in the Visual Studio menu, or press `Ctrl+Shift+B`.

### Steps to Run
1. After building the solution, click the **Start** button in Visual Studio, or press `F5` to run the application.
2. The application window will launch with three main options:
   - **Report Issues**: Submit a new municipal issue with detailed information.
   - **Local Events and Announcements**: Search and view local events, with recommendations based on user patterns.
   - **Service Request Status**: View and track service requests, including related requests.

---

## Using the Program

### Report an Issue
1. Navigate to the **Report Issues** section.
2. Fill in the required fields:
   - **Location**: Enter the location of the issue.
   - **Category**: Select the appropriate category (e.g., Sanitation, Roads, Utilities).
   - **Description**: Provide a detailed description of the issue.
   - **Attach File**: Optionally, attach an image or document.
3. Submit the form. A confirmation message will appear.

### View Local Events
1. Navigate to the **Local Events and Announcements** section.
2. Use the search box to filter events by name or category.
3. Perform at least five searches to enable recommendations based on your preferences.

### Service Request Status
1. Navigate to the **Service Request Status** section.
2. View a list of all service requests, including their **ID**, **Name**, **Location**, **Category**, and **Status**.
3. Select a request to view related requests. A custom window will display detailed information about dependencies and related requests.

---

### Data Structures Used and Their Roles (Implementation Report)
1. **Binary Search Tree (BST)**:
   - **Purpose**: Organizes and retrieves service requests efficiently.
   - **Implementation**: 
     - The BST stores service requests by their unique ID, allowing quick insertion, deletion, and traversal operations.
   - **Contribution to Efficiency**:
     - **In-Order Traversal**: Displays service requests in a sorted manner.
     - **Search Operation**: Quickly retrieves specific service requests for displaying or relationship mapping.
   - **Example**:
     - Service requests are inserted into the BST using their unique ID. For instance, request `ID = 3` ("Power Outage") can be efficiently located and displayed.

2. **Graph**:
   - **Purpose**: Manages relationships between service requests.
   - **Implementation**: 
     - Represents service requests as nodes and their dependencies as directed edges.
   - **Contribution to Efficiency**:
     - Allows identification of related service requests, enabling users to understand dependencies or concurrent tasks.
   - **Example**:
     - If `Request 1` ("Water Leak") depends on `Request 3` ("Power Outage"), this relationship is captured in the graph, allowing the "Related Requests" feature to display dependencies.

3. **Custom ListView**:
   - **Purpose**: Displays structured data for user interaction.
   - **Implementation**: 
     - Enhanced with data binding to show details like **ID**, **Name**, **Category**, and **Status**.
   - **Contribution to Efficiency**:
     - Provides a user-friendly view of the organized data, facilitating quick navigation and interaction.

---

### Contribution of Data Structures to "Service Request Status"
- The **Binary Search Tree** ensures that the list of service requests is always organized and accessible.
- The **Graph** structure supports advanced features like dependency analysis, enhancing user insights into municipal operations.
- The combination of these structures underpins the "Related Requests" feature, ensuring that complex relationships are displayed seamlessly.

---

## License
This project is licensed under the MIT License.
