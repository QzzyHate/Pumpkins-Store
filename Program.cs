var builder = WebApplication.CreateBuilder();
var app = builder.Build();

List<Pumpkins> pumpkinsStore = new List<Pumpkins>
{
    new Pumpkins("Тыква Классическая", "Амазонка", "Classic scary carved Jack O’Lantern", "Ярко-оранжевая", 20, 700, 359),
    new Pumpkins("Тыква с двойной головой", "Атлантик", "A two-headed monster pumpkin!", "Бледно-желтая", 40, 1500, 659),
    new Pumpkins("Ужастная тыква", "Августина", "Nightmare pumpkin", "Оранжевая",28, 850, 499)
};
//Read
app.MapGet("/", () => pumpkinsStore);

//Create
app.MapPost("/", (Pumpkins newPumpkin) =>
{
    pumpkinsStore.Add(newPumpkin);
    return Results.Ok();
});

//Update
app.MapPut("/{name}", (string name, PumpkinsDTO dto) =>
{
    Pumpkins buffer = pumpkinsStore.Find(p => p.pumpkinName == name);

    buffer.pumpkinSize = dto.pumpkinSize == 0 ? buffer.pumpkinSize : dto.pumpkinSize;
    buffer.pumpkinWeight = dto.pumpkinWeight == 0 ? buffer.pumpkinWeight : dto.pumpkinWeight;
    buffer.pumpkinPrice = dto.pumpkinPrice == 0 ? buffer.pumpkinPrice : dto.pumpkinPrice;
});

//Delete
app.MapDelete("/delete/{name}", (string name) =>
{
    Pumpkins buffer = pumpkinsStore.Find(p => p.pumpkinName == name);
    pumpkinsStore.Remove(buffer);
});

app.Run();

record class PumpkinsDTO ( float  pumpkinSize, float pumpkinWeight, float pumpkinPrice);

class Pumpkins
{
    public Pumpkins(string pumpkinName, string pumpkinVariety, string pumpkinFaceType, string pumpkinColor, float pumpkinSize, float pumpkinWeight, float pumpkinPrice)
    {
        this.pumpkinName = pumpkinName;
        this.pumpkinVariety = pumpkinVariety;
        this.pumpkinFaceType = pumpkinFaceType;
        this.pumpkinColor = pumpkinColor;
        this.pumpkinSize = pumpkinSize;
        this.pumpkinWeight = pumpkinWeight;
        this.pumpkinPrice = pumpkinPrice;
    }

    public string pumpkinName { get; set; }
    public string pumpkinVariety { get; set; }
    public string pumpkinFaceType { get; set; }
    public string pumpkinColor { get; set; }
    public float pumpkinSize { get; set; }
    public float pumpkinWeight { get; set; }
    public float pumpkinPrice { get; set; }
}
