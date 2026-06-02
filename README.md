# TSPG_API

TSPG API Repository — 基於 .NET 8 / C# 7.3 的 OpenAPI 服務。

## 專案列表

| 專案 | 說明 |
|------|------|
| TWQRP | Open API 服務，提供 API 基本資訊查詢 |

---

## TWQRP

### 環境需求

- .NET 8 SDK
- C# 7.3

### 啟動方式

```bash
cd TWQRP
dotnet run --launch-profile http
```

啟動後開啟瀏覽器前往 `http://localhost:5042` 即可看到 Swagger UI。

### API 端點

#### POST /api/App/AppInfo

回傳 API 基本資訊。

**Request**
```
POST http://localhost:5042/api/App/AppInfo
```

**Response**
```json
{
  "apiName": "TWQRP",
  "buildDate": "2026/06/02 10:15:30",
  "version": "1.0.0.0"
}
```

| 欄位 | 說明 |
|------|------|
| apiName | API 名稱 |
| buildDate | 建置日期（yyyy/MM/dd HH:mm:ss） |
| version | 版本號 |

---

## 歷程

| 日期 | 分支 | 摘要 |
|------|------|------|
| 2026/06/02 | `main` | 初始建立 TWQRP .NET 8 / C# 7.3 OpenAPI 專案，新增 POST /api/App/AppInfo 端點，回傳 API 名稱、建置日期及版本號 |
| 2026/06/02 | `docs/add-readme` | 新增 README.md，說明專案簡介、啟動方式及 API 端點使用範例 |
| 2026/06/02 | `fix/code-review-improvements` | 套用程式碼審查改善：Swagger 限制開發環境、assembly.Location 防禦性處理、屬性預設值、Controller XML 摘要、static readonly 快取靜態資訊 |
