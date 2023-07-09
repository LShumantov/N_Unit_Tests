


namespace TheRace.Tests
{
    using NUnit.Framework;
    class UnitDriverTest
    {
        private UnitCar defaultUnitCar;       
        private UnitDriver defaultUnitDriver;
        private readonly string nameFirstDriver = "Gosho";     
        [SetUp]
        public void Setup()
        {
            this.defaultUnitDriver = new UnitDriver(nameFirstDriver, defaultUnitCar);         
        }
        [Test]
        public void CheckTheDriverConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.nameFirstDriver, this.defaultUnitDriver.Name);
            Assert.AreEqual(this.defaultUnitCar, this.defaultUnitDriver.Car);
        }
    }
}
