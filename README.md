# WebScraper

## Application Description

This full-stack application allows users to check the ranking position of a specific URL for a given keyword on search engines Google and Bing. It accepts a keyword and a target URL, performs a live search, identifies the ranking positions of the target URL, and returns the results. It also logs each search into a JSON file so historical rank data can be referenced.


## Project Structure

- `WebScraper.API` – ASP.NET Core Web API project exposing endpoints.
- `WebScraper.Application` – Contains business logic, DTOs, and core services.
- `WebScraper.Domain` – Defines domain models like `SearchResult`.
- `WebScraper.Infrastructure` – Provides concrete implementations for search engine services and search history logging.
- `WebScraper.Client` – Vue 3 + TypeScript single-page app that interacts with the API and displays results.

## How to Run

### Prerequisites

- Visual Studio 2022+ with ASP.NET Core workload
- Node.js and npm (for the Vue client)


### Running with Multiple Startup Projects (Recommended)

1. Open the solution `WebScraper.sln` in Visual Studio.
2. Right-click the solution and choose **Set Startup Projects**.
3. Select **Multiple startup projects** and set both:
   - `WebScraper.API` to **Start**
   - `WebScraper.Client` to **Start**
4. Run the solution (press `F5` or click the green play button).
5. The backend will run at  `https://localhost:7196`


## Potential Challenges

- **Google Blocking Requests**: Google may block automated requests, especially when many searches are done in a short time. This can cause timeouts or empty results. Bing tends to work more reliably and is recommended during testing.
  
- **SSL Errors**: If you get the error message `"The SSL connection could not be established"`, please perform the search again by clicking on the search button.

