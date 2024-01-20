namespace Services.CatService
{
    public class CatService : ICatService
    {
        private Guid Field { get; set; } = Guid.NewGuid();

        public CatService() => Console.WriteLine($"Я вызвался {Field}");

        public string Meow()
        {
            return $"Meow {Field}";
        }
    }
}
