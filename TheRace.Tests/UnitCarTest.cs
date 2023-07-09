namespace TheRace.Tests
{
    using NUnit.Framework;
    class UnitCarTest
    {
        private UnitCar defaultUnitCar;
        private readonly string model = "Mercedes";
        private readonly int horsePower = 78;
        private readonly double cubicCentimeters = 350d; 
        [SetUp]
        public void Setup()
        {
        this.defaultUnitCar = new UnitCar(model, horsePower, cubicCentimeters);
        }
        [Test]
        public void CheckTheCarConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.model, this.defaultUnitCar.Model);
            Assert.AreEqual(this.horsePower, this.defaultUnitCar.HorsePower);
            Assert.AreEqual(this.cubicCentimeters, this.defaultUnitCar.CubicCentimeters);
        }   
    }
}
