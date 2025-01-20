Blazor Investment Management
This project is a Blazor application for managing investments, funds, and investors. It interacts with a web API to perform CRUD operations and display data in a user-friendly interface.
Features
•	View, create, update, and delete investments.
•	View and manage funds.
•	View and manage investors.
•	Responsive UI built with Blazor.
•	Data validation and error handling.
Prerequisites
•	.NET 9 SDK
•	Visual Studio 2022 or later with Blazor support.
Getting Started
1.	Clone the repository:
    git clone https://github.com/your-repo/blazor-investment-management.git
    cd blazor-investment-management

Project Structure
•	BlazorUI: Contains the Blazor components and pages.
•	Pages: Razor components for different pages like Investments.razor.
•	Services: Service classes for interacting with the web API, e.g., FundApiService.cs.
•	wwwroot: Static files like CSS and JavaScript.
•	Models: Contains the data transfer objects (DTOs) used in the application.
•	DTOs: DTO classes like FundDTO, InvestmentDTO, and InvestorDTO.

Key Files
•	BlazorUI/Pages/Investments.razor: The main page for managing investments.
•	BlazorUI/Services/FundApiService.cs: Service class for interacting with the fund-related API endpoints.
•	BlazorUI/Services/IFundApiService.cs: Interface for FundApiService.
API Endpoints
The application interacts with the following API endpoints:
•	GET api/fund: Retrieves all funds.
•	GET api/fund/{id}: Retrieves a single fund by ID.
•	POST api/fund: Creates a new fund.
•	PUT api/fund/{id}: Updates an existing fund.
•	DELETE api/fund/{id}: Deletes a fund by ID.

Screenshoots

![image](https://github.com/user-attachments/assets/e87e8aa9-6a89-4d71-8c06-57271b962f80)
Funds Page ->
![image](https://github.com/user-attachments/assets/ab611800-d27a-4c22-ae05-1b17b33635fc)
Add Fund Page
![image](https://github.com/user-attachments/assets/121ea0ee-786d-47e5-8078-b35cac28c214)
List of Investors
![image](https://github.com/user-attachments/assets/7f0863d3-c589-4ad2-a714-177ba609e99e)
Edit Investor
![image](https://github.com/user-attachments/assets/74569a4f-b835-4072-929c-8f4b555d05de)
User's Investments 
![image](https://github.com/user-attachments/assets/c2ac312e-d1a4-464c-b044-2fa055249330)




