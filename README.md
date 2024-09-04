# Municipal Services Application

## Overview
This project is a **C# .NET Framework** desktop application designed to streamline municipal services for citizens in South Africa. It allows users to report issues, access local event announcements, and check the status of their service requests (only the "Report Issues" feature is implemented in this phase).

## Features
- **Report Issues**: Users can report municipal issues like sanitation, road problems, and utility concerns. They can attach a file related to the issue and submit a detailed description.
- **Local Events and Announcements** (To be implemented in future phases).
- **Service Request Status** (To be implemented in future phases).

## Technologies Used
- **C# .NET Framework** (WPF)
- **XAML** for UI design
- **Visual Studio 2022** as the IDE
- **WPF Controls** for handling user interaction

## How to Compile and Run the Program

### Prerequisites
1. **Visual Studio 2022** (or later) with the **.NET Framework** installed.
2. **.NET Framework 4.7.2** (or later).

### Steps to Compile
1. Clone or download this repository to your local machine.
2. Open the solution file (`Part_1.sln`) in Visual Studio.
3. Build the solution by selecting **Build** > **Build Solution** in the Visual Studio menu, or press `Ctrl+Shift+B`.

### Steps to Run
1. After building the solution, click the **Start** button in Visual Studio, or press `F5` to run the application.
2. The application window will launch with three main options:
   - **Report Issues**: This feature is implemented and functional.
   - **Local Events and Announcements** (Disabled).
   - **Service Request Status** (Disabled).
   
3. Select **Report Issues** to submit an issue. You can enter a location, choose a category, provide a description, attach a file, and submit the issue. After 3 seconds, you will be redirected to the main screen.

## Using the Program
### Report an Issue
1. **Enter Location**: Type the location of the issue.
2. **Select Category**: Choose from sanitation, roads, or utilities.
3. **Description**: Provide a detailed description of the issue.
4. **Attach File**: Optionally, attach an image or document related to the issue.
5. **Submit**: Click the "Submit Issue" button to submit. A progress bar will show the submission status.
6. After submission, you will be returned to the main menu after a brief delay.

### Other Features
- **Back to Main Menu**: Use the "Back to Main Menu" button to return to the main screen.

## Future Development
In future versions of the Municipal Services Application:
- **Local Events and Announcements** will provide citizens with information about upcoming events.
- **Service Request Status** will allow users to track their issue reports.

## License
This project is licensed under the MIT License.

