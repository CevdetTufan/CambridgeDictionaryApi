# CambridgeDictionaryApi

A lightweight, SOLID-principled .NET client library for accessing the [Cambridge Dictionary API](https://dictionary-api.cambridge.org/).  
Supports both JSON responses and strongly typed models.

## 🚀 Features

- Get dictionary list, entries, and nearby entries
- Handle success and error responses cleanly
- Strongly-typed deserialization support
- Built-in `ApiResponse<T>` result wrapper
- Easily testable with dependency injection

---

## 🔧 Installation

This is a class library project. You can clone and reference it directly:

```bash
git clone https://github.com/CevdetTufan/CambridgeDictionaryApi.git
```

Or add it to your solution as a project reference.

---

## 🛠️ Configuration

1. Get an API key from [Cambridge Dictionary API](https://dictionary-api.cambridge.org/apply).
2. In your `appsettings.json`:

```json
"CambridgeApi": {
  "ApiKey": "YOUR_API_KEY",
  "BaseUrl": "https://dictionary.cambridge.org/api/v1/"
}
```

3. Register services in `Program.cs` or `Startup.cs`:

```csharp
builder.Services.Configure<CambridgeApiOptions>(builder.Configuration.GetSection("CambridgeApi"));
builder.Services.AddHttpClient<ICambridgeRequestHandler, CambridgeRequestHandler>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<CambridgeApiOptions>>().Value;
    client.BaseAddress = new Uri(options.BaseUrl);
});
builder.Services.AddScoped<ICambridgeApiClient, CambridgeApiClient>();
```

---

## ✅ Usage

### Get dictionaries

```csharp
var response = await _cambridgeApiClient.GetDictionariesAsync();

if (response.IsSuccess)
{
    foreach (var dict in response.Data)
    {
        Console.WriteLine(dict.DictionaryName);
    }
}
else
{
    Console.WriteLine($"Error: {response.Error?.ErrorMessage}");
}
```

## 📦 Models

- `DictionaryResponseModel`
- `ApiResponse<T>`
- `ApiErrorResponse`

> More models can be added as needed based on Cambridge API response schemas.

---

## 🧪 Testing

This library is fully testable. You can mock `ICambridgeRequestHandler` for unit tests without hitting the actual API.

---

## 📄 License

MIT – free for personal or open source use.

---

## 🙌 Contributions

Feel free to fork the project and submit a PR. Feedback and improvements are welcome!

