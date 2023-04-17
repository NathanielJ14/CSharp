Vehicle CrownVic = new Vehicle("Crown Vic", 4, "Baby Blue", true);
Vehicle FordTransit = new Vehicle("Ford Transit", "Black");
Vehicle GmcSierra = new Vehicle("GMC Sierra", "Red");
Vehicle DodgeDakota = new Vehicle("Dodge Dakota", 3, "Blue", false);

List<Vehicle> cars = new List<Vehicle>();
cars.Add(CrownVic);
cars.Add(FordTransit);
cars.Add(GmcSierra);
cars.Add(DodgeDakota);


FordTransit.Travel(100);

foreach (Vehicle car in cars)
{
    car.ShowInfo();
}