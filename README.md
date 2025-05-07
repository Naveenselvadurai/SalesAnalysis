# Sales Analysis API

## 📋 Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
- MongoDB (local or cloud)

## ⚙️ Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/Naveenselvadurai/SalesAnalysis
   cd SalesAnalysis

## Table
   | Method | Route                      | Request Body (example)                                        | Sample Response (example)      | Description                              |
| ------ | -------------------------- | ------------------------------------------------------------- | ------------------------------ | ---------------------------------------- |
| POST   | `/api/sales/upload-csv`    | `multipart/form-data` with a `file` field                     | `"Data loaded successfully."`  | Uploads a CSV file and stores data in DB |
| GET    | `/api/sales/total-revenue` | *Query parameters*: `startDate=2024-01-01&endDate=2024-01-31` | `{ "totalRevenue": 25000.75 }` | Returns total revenue between two dates  |

