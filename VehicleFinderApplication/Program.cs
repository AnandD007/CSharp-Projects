using System.Text.RegularExpressions;

namespace VehicleFinder
{
    class Program: VehicleType
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=Welcome To Mega Vehicle Finder=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=\n");
            VehicleType vehicle = new VehicleType();
            vehicle.VehicleTypeInput();

        }
    }
    public class VehicleType
    {
        
        protected string vehicleTypeUserInput = "";
        protected string vehicleModelType = "";
        protected Regex regexForAlphaValue = new Regex(@"[\d]");
        internal void VehicleTypeInput()
        {
            Console.Write("\n\nChoose the Vehicle Type (1.Two Wheeler, 2.Four Wheeler(Car)): ");
            ChoiceVehicleTypeUserInputCheck:
            this.vehicleTypeUserInput = Console.ReadLine().ToLower();

            // add validations           

            if (string.IsNullOrEmpty(this.vehicleTypeUserInput) || string.IsNullOrWhiteSpace(this.vehicleTypeUserInput))
            {
                Console.Write("\nVehicle Type name should be not null..!\n\nChoose the Vehicle Type (1.Two Wheeler, 2.Four Wheeler(Car)):");
                goto ChoiceVehicleTypeUserInputCheck;
            }
            if (regexForAlphaValue.IsMatch(this.vehicleTypeUserInput))
            {
                Console.Write("\nLetters should be alphabets...!\n\nChoose the Vehicle Type (1.Two Wheeler, 2.Four Wheeler(Car)):");
                goto ChoiceVehicleTypeUserInputCheck;
            }
            if (vehicleTypeUserInput == "car" || vehicleTypeUserInput == "four wheeler")
            {
                FourWheelerVehicle userInputObject = new FourWheelerVehicle();
                userInputObject.FourWheelerType();
                Environment.Exit(0);
            }
            else if(vehicleTypeUserInput == "two wheeler" || vehicleTypeUserInput == "twowheeler")
            {
                TwoWheelerVehicle userInputObject = new TwoWheelerVehicle();
                userInputObject.TwoWheelerType();
                Environment.Exit(0);
            }
            else
            {
                Console.Write("\n\nChoose the Correct Vehicle Type (1.Two Wheeler, 2.Four Wheeler(Car)): ");
                goto ChoiceVehicleTypeUserInputCheck;
            }
            Console.ReadKey();
        }
    }
}