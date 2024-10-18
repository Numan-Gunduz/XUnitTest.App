namespace UnitTest.App
{
    public class Calculater
    {
        private ICalculaterService _calculaterService { get; set; }
        public Calculater(ICalculaterService calculaterService)
        {

            this._calculaterService = calculaterService;

        }
        public int add(int a, int b)
        {
            return _calculaterService.add(a, b);
        }

        public int Mul(int a, int b)
        {
            return _calculaterService.Mul(a, b);
        }
    }
}
