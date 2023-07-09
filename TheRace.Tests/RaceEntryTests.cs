namespace TheRace.Tests
{
    using System;
    using NUnit.Framework;    
    public class RaceEntryTests
    {
        private UnitCar defaultUnitCar;
        private readonly string model = "Mercedes";
        private readonly int horsePower = 78;
        private readonly double cubicCentimeters = 350d;
        private UnitDriver defaultUnitDriver;
        private readonly string nameFirstDriver = "Gosho";
        private UnitDriver defaultUnitDriverForTestCalculateAverageHorsePower;
        private readonly string nameSecondDriver = "Ivan";
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.defaultUnitCar = new UnitCar(model, horsePower, cubicCentimeters);
            this.defaultUnitDriver = new UnitDriver(nameFirstDriver, defaultUnitCar);
            this.defaultUnitDriverForTestCalculateAverageHorsePower = new UnitDriver(nameSecondDriver, defaultUnitCar);
            this.raceEntry = new RaceEntry();
        }     
        [Test]
        public void CheckRaceConstructorWorksCorrectly()
        {
            Assert.That(this.raceEntry.Counter, Is.EqualTo(0));
        }
        [Test]
        public void CheckIfRaceCounterWorksCorrectly()
        {
            this.raceEntry.AddDriver(this.defaultUnitDriver);
            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
        }
        [Test]
        public void AddShouldIncreaseCountWhenSuccessful()
        {
            var returnResult = this.raceEntry.AddDriver(this.defaultUnitDriver);         
            var defaultDriverStringFormat = string.Format("Driver {0} added in race.", defaultUnitDriver.Name);
            Assert.That(defaultDriverStringFormat, Is.EqualTo(returnResult));
        }
        [Test]
        public void AddShouldInvalidOperationExceptionWithNullValue()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddDriver(null);
            },
            "Driver cannot be null."
            );
        }
        [Test]
        public void AddDriverThrowExceptionWithExistingDriver()
        {
            this.raceEntry.AddDriver(this.defaultUnitDriver);         
            var throwExceptionWithExistingDriver = string.Format("Driver {0} is already added.", defaultUnitDriver.Name);
            var ex = Assert.Throws<InvalidOperationException>(()
                     => this.raceEntry.AddDriver(this.defaultUnitDriver));
            Assert.That(ex.Message.Equals(throwExceptionWithExistingDriver));
        }
        [Test]
        public void CalculateAverageHorsePower()
        {
            this.raceEntry.AddDriver(defaultUnitDriver);
            this.raceEntry.AddDriver(defaultUnitDriverForTestCalculateAverageHorsePower);
            var result = this.raceEntry.CalculateAverageHorsePower();
            double expectedResult = 78d;
            Assert.That(result.Equals(expectedResult));
        }
        [Test]
        public void MinParticipantsInvalidOperationException()        {
            this.raceEntry.AddDriver(defaultUnitDriver);                      
            var minParticipants = 2;
            var throwOperationException = string.Format("The race cannot start with less than {0} participants.", minParticipants);
            var ex = Assert.Throws<InvalidOperationException>(()
                     => this.raceEntry.CalculateAverageHorsePower());

            Assert.That(ex.Message.Equals(throwOperationException));
        }
    }
}
    