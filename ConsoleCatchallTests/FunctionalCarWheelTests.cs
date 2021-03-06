﻿using NUnit.Framework;

namespace ConsoleCatchallTests
{
    // This is here because when I did the functional programming workshop at OOP 2017 in Munich,
    // the lecturer got stuck trying to implement a function which could calculate the number of cars
    // in a scenario where a car park contains only cars and motorcycles, wnd we know the number of wheels
    // and the number of vehicles, and want to calculate the number of cars.
    // One of the workshop participants suggested using a test driven approach, and it all fell apart.
    // But the lecturer (Mike - who had never used TDD before) believed that the thing he had learnt from it was that TDD 
    // could identify the point at which your domain logic should take over in finding a solution ot a problem.
    // I wasn't convinced but couldn't follow the conversation in German, and anyway was more focused on just learning the
    // functional programming. I was then emailed later on by the guy who'd started trying to do TDD in the first place...
    // ...because he (Thomas)'d carried on thinking about it after the workshop was over.
    // The first tests represent Thomas's TDD approach
    [TestFixture]
    public class FunctionalCarWheelTests
    {
        [Test]
        public void WithNoVehicles_AndNoWheels_ThereAreNoCars()
        {
            // Arrange
            const int numVehicles = 0;
            const int numWheels = 0;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(0, num_cars);
        }

        [Test]
        public void With1Vehicle_And4Wheels_ThereIs1Car()
        {
            // Arrange
            const int numVehicles = 1;
            const int numWheels = 4;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(1, num_cars);
        }

        [TestCase(3, 12)]
        [TestCase(4, 16)]
        [TestCase(5, 20)]
        [TestCase(30, 120)]
        [TestCase(17, 68)]
        public void WithManyVehicles_AndWheelsIsVehiclesTimes4_TheyAreAllCars(int num_vehicles, int num_wheels)
        {
            // Act
            int num_cars = Find_number_of_cars(num_vehicles, num_wheels);

            // Assert
            Assert.AreEqual(num_vehicles, num_cars);
        }

        [Test]
        public void With1Vehicle_And2Wheels_ThereAreNoCars()
        {
            // Arrange
            const int numVehicles = 1;
            const int numWheels = 2;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(0, num_cars);
        }

        [Test]
        public void With2Vehicles_And4Wheels_ThereAreNoCars()
        {
            // Arrange
            const int numVehicles = 2;
            const int numWheels = 4;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(0, num_cars);
        }

        [Test]
        public void With2Vehicles_And6Wheels_ThereIs1Car()
        {
            // Arrange
            const int numVehicles = 2;
            const int numWheels = 6;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(1, num_cars);
        }

        [Test]
        public void With4Vehicles_And12Wheels_ThereAre2Cars()
        {
            // Arrange
            const int numVehicles = 4;
            const int numWheels = 12;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(2, num_cars);
        }

        [Test]
        public void With3Vehicles_And10Wheels_ThereAre2Cars()
        {
            // Arrange
            const int numVehicles = 3;
            const int numWheels = 10;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(2, num_cars);
        }

        [Test]
        public void With3Vehicles_And8Wheels_ThereIs1Car()
        {
            // Arrange
            const int numVehicles = 3;
            const int numWheels = 8;

            // Act
            int num_cars = Find_number_of_cars(numVehicles, numWheels);

            // Assert
            Assert.AreEqual(1, num_cars);
        }

        private int Find_number_of_cars(int num_vehicles, int num_wheels)
        {
            int num_wheels_if_all_vehicles_are_motorbikes = num_vehicles*2;
            int num_leftover_wheels = num_wheels - num_wheels_if_all_vehicles_are_motorbikes;

            int num_cars = num_leftover_wheels / 2;

            return num_cars;
        }
    }
}
