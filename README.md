# FakeUsersApp

FakeUsersApp is a web application designed to generate realistic fake user data for testing, development, and demonstration purposes. Built with ASP.NET Core MVC, it provides a flexible and interactive interface for creating user records tailored to specific countries, with options to simulate data errors and export results for further use.

---

## What Does FakeUsersApp Do?

FakeUsersApp helps developers, QA engineers, and data analysts quickly create large sets of fake user data. This data can be used to test applications, validate data processing pipelines, or showcase software features without exposing real user information. The app supports generating data for multiple countries, simulating common data entry errors, and exporting the results in CSV format.

---

## Features

- **Country-Specific Data Generation:**  
  Generate user records for Georgia, USA, and Italy, with localized names, addresses, and phone numbers.

- **Error Simulation:**  
  Introduce realistic errors (typos, swapped letters, missing/extra characters) into the data to test how systems handle imperfect input.

- **Seed-Based Generation:**  
  Use a seed value to produce deterministic data sets, ensuring repeatable results for testing.

- **Infinite Scrolling:**  
  Load more data as you scroll, making it easy to work with large datasets without overwhelming the browser.

- **CSV Export:**  
  Download the generated data as a CSV file for use in spreadsheets, databases, or other applications.

- **Responsive UI:**  
  Built with Bootstrap for a clean, mobile-friendly interface.

---

## Technologies Used

- **ASP.NET Core MVC:**  
  Provides the web framework and server-side logic.

- **Bogus:**  
  Generates realistic fake data for names, addresses, and other user details.

- **CsvHelper:**  
  Handles CSV export functionality.

- **Bootstrap:**  
  Ensures a responsive and modern user interface.

- **jQuery:**  
  Powers client-side interactions, including infinite scrolling and AJAX requests.

---

## Project Structure

```
FakeUsersApp/
├── Controllers/
│   └── HomeController.cs
├── Models/
│   ├── FakeDataGenerator.cs
│   ├── ErrorGenerator.cs
│   └── PersonModel.cs
├── ViewModels/
│   └── FakeDataViewModel.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   └── Shared/
│       └── _FakeTabledata.cshtml
├── wwwroot/
│   ├── css/
│   └── js/
├── appsettings.json
└── Program.cs
```

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022+ or VS Code

### Installation & Running

1. **Clone the repository:**
   ```sh
   git clone <your-repo-url>
   cd FakeUsersApp
   ```

2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

3. **Build the project:**
   ```sh
   dotnet build
   ```

4. **Run the application:**
   ```sh
   dotnet run --project FakeUsersApp/FakeUsersApp.csproj
   ```
   The app will be available at `http://localhost:5263` (see launchSettings.json).

---

## Usage

1. Select a country from the dropdown.
2. Optionally set a seed for deterministic data.
3. Adjust error probability and errors per record.
4. Click **Submit** to generate fake users.
5. Scroll down to load more data automatically.
6. Click **Export to CSV** to download the generated data.

---

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements or bug fixes.

---

## License

This project uses open source libraries under the MIT and Apache licenses. See the respective `LICENSE` files in `wwwroot/lib/`.
