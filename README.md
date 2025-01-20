<h1>Blazor Investment Management</h1>
<p>
This project is a Blazor application for managing investments, funds, and investors. It interacts with a web API to perform CRUD operations and display data in a user-friendly interface.</p>
<h6>Features</h6>
<ul>
<li>View, create, update, and delete investments.</li>
<li>View and manage funds.</li>
<li>View and manage investors.</li>
<li>Responsive UI built with Blazor.</li>
<li>Data validation and error handling.</li>
</ul>
<hr/>
<h6>Prerequisites</h6>
<ul>
<li>.NET 9 SDK</li>
<li>Visual Studio 2022 or later with Blazor support.</li>
</ul>
<h6>Getting Started</h6>
1.	Clone the repository:
    git clone https://github.com/your-repo/blazor-investment-management.git
    cd blazor-investment-management

<h6>Project Structure</h6>
<ul>
<li>BlazorUI: Contains the Blazor components and pages.</li>
<li>Pages: Razor components for different pages like Investments.razor.</li>
<li>Services: Service classes for interacting with the web API, e.g., FundApiService.cs.</li>
<li>wwwroot: Static files like CSS and JavaScript.</li>
<li>Models: Contains the data transfer objects (DTOs) used in the application.</li>
<li>DTOs: DTO classes like FundDTO, InvestmentDTO, and InvestorDTO.</li>
</ul>

<h6>Key Files</h6>

<ul>
<li>BlazorUI/Pages/Investments.razor: The main page for managing investments.</li>
<li>BlazorUI/Services/FundApiService.cs: Service class for interacting with the fund-related API endpoints.</li>
<li>BlazorUI/Services/IFundApiService.cs: Interface for FundApiService.</li>
</ul>
<h6>API Endpoints</h6>
The application interacts with the following API endpoints:
<ul>
<li>GET api/fund: Retrieves all funds.</li>
<li>GET api/fund/{id}: Retrieves a single fund by ID.</li>
<li>POST api/fund: Creates a new fund.</li>
<li>PUT api/fund/{id}: Updates an existing fund.</li>
<li>DELETE api/fund/{id}: Deletes a fund by ID.</li>
</ul>

<h6>Screenshoots</h6>

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




