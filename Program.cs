var builder = WebApplication.CreateBuilder();
var app = builder.Build();

List<Pumpkins> pumpkinsStores = new List<Pumpkins>
{
    new Pumpkins("Тыква Классическая", "Амазонка", "Classic scary carved Jack O’Lantern", "Ярко-оранжевая", 20, 700, 359)
};

app.MapGet("/", () => pumpkinsStores);

app.MapPut("/{name}", (string name, PumpkinsDTO dto) =>
{
    Pumpkins buffer = pumpkinsStores.Find(p => p._pumpkinName == name);

    buffer._pumpkinSize = dto.pumpkinSize == 0 ? buffer._pumpkinSize : dto.pumpkinSize;
    buffer._pumpkinWeight = dto.pumpkinWeight == 0 ? buffer._pumpkinWeight : dto.pumpkinWeight;
    buffer._pumpkinPrice = dto.pumpkinPrice == 0 ? buffer._pumpkinPrice : dto.pumpkinPrice;
});

app.MapDelete("/delete/{name}", (string name) =>
{
    Pumpkins buffer = pumpkinsStores.Find(p => p._pumpkinName == name);
    pumpkinsStores.Remove(buffer);
});

app.Run();

record class PumpkinsDTO ( float  pumpkinSize, float pumpkinWeight, float pumpkinPrice);

class Pumpkins
{
    public Pumpkins(string pumpkinName, string pumpkinVariety, string pumpkinFaceType, string pumpkinColor, float pumpkinSize, float pumpkinWeight, float pumpkinPrice)
    {
        _pumpkinName = pumpkinName;
        _pumpkinVariety = pumpkinVariety;
        _pumpkinFaceType = pumpkinFaceType;
        _pumpkinColor = pumpkinColor;
        _pumpkinSize = pumpkinSize;
        _pumpkinWeight = pumpkinWeight;
        _pumpkinPrice = pumpkinPrice;
    }

    public string _pumpkinName { get; set; }
    public string _pumpkinVariety { get; set; }
    public string _pumpkinFaceType { get; set; }
    public string _pumpkinColor { get; set; }
    public float _pumpkinSize { get; set; }
    public float _pumpkinWeight { get; set; }
    public float _pumpkinPrice { get; set; }
}
