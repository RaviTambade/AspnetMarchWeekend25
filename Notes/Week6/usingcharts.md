Using **Chart.js** in **ASP.NET Core Razor views** is a great way to render interactive charts like bar, line, pie, etc., using **JavaScript + HTML5 Canvas** — and you can bind them with **server-side Razor data**. Here’s a step-by-step guide to doing it cleanly. 👇

---

## 📊 Step-by-Step: Using Chart.js in ASP.NET Core

---

### ✅ 1. Install Chart.js in Your View (via CDN)

In your Razor `.cshtml` view or layout (`_Layout.cshtml`):

```html
<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
```

> ✅ Tip: Put this before your closing `</body>` tag for best performance.

---

### ✅ 2. Add a `<canvas>` Element

```html
<canvas id="myChart" width="400" height="200"></canvas>
```

---

### ✅ 3. Pass Razor Data to JavaScript

Example: Let's assume your controller sends a model like:

```csharp
public class SalesViewModel
{
    public List<string> Labels { get; set; }
    public List<decimal> Values { get; set; }
}
```

And in your controller:
```csharp
public IActionResult Chart()
{
    var model = new SalesViewModel
    {
        Labels = new List<string> { "Jan", "Feb", "Mar" },
        Values = new List<decimal> { 1200, 1900, 3000 }
    };

    return View(model);
}
```

---

### ✅ 4. Serialize Razor Model to JS with JSON

```csharp
@model SalesViewModel
@using System.Text.Json

<script>
    const labels = @Html.Raw(JsonSerializer.Serialize(Model.Labels));
    const data = @Html.Raw(JsonSerializer.Serialize(Model.Values));
</script>
```

---

### ✅ 5. Initialize Chart.js

```html
<script>
    const ctx = document.getElementById('myChart').getContext('2d');

    const myChart = new Chart(ctx, {
        type: 'bar', // bar, line, pie, etc.
        data: {
            labels: labels,
            datasets: [{
                label: 'Sales',
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.5)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
</script>
```

---

## ✅ Final Razor View (Summary)

```csharp
@model SalesViewModel
@using System.Text.Json

<h2>Monthly Sales</h2>
<canvas id="myChart" width="400" height="200"></canvas>

<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

<script>
    const labels = @Html.Raw(JsonSerializer.Serialize(Model.Labels));
    const data = @Html.Raw(JsonSerializer.Serialize(Model.Values));

    const ctx = document.getElementById('myChart').getContext('2d');

    const myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Sales',
                data: data,
                backgroundColor: 'rgba(75, 192, 192, 0.5)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
</script>
```

---

## 💡 Chart Types in Chart.js

- `'bar'` – vertical bars
- `'line'` – line chart
- `'pie'` – pie slices
- `'doughnut'` – circular with hole
- `'radar'`, `'polarArea'`, etc.

---

## 🔒 Best Practices

| Tip | Why |
|-----|-----|
| Use `@Html.Raw(JsonSerializer.Serialize(...))` | Clean and secure JSON |
| Escape Razor values properly | Avoid XSS / JS errors |
| Use layout (`_Layout.cshtml`) for script reuse | DRY structure |
| Keep charts in a `<script>` block, not external files if using Razor data | JS files can't access Razor directly |



