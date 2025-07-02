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


### Running the API

- Open the solution in Visual Studio.

- Set WebScraper.API as the startup project.

- Run the API (F5 or Ctrl+F5).

- It should run on https://localhost:7196 (check launchSettings.json if not).

### Running the Client

- Open a terminal:

- cd WebScraper.Client

- npm install

- npm run dev


## Potential Challenges

- **Google Blocking Requests**: Google may block automated requests, especially when many searches are done in a short time. This can cause timeouts or empty results. Bing tends to work more reliably and is recommended during testing.
  
- **SSL Errors**: If you get the error message `"The SSL connection could not be established"`, please perform the search again by clicking on the search button.

