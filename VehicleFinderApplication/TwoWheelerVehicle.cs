using System.Text.RegularExpressions;


namespace VehicleFinder
{

    public class TwoWheelerVehicle : TwoWheeler
    {

        protected string modelType = "";
        protected long distributorCommission = 0;
        protected string[] twoWheelerModelChoices = new string[100];
        protected string[] twoWheelerModelPrices = new string[100];
        protected string twoWheelerTypeInput = "";
        protected string twoWheelerCompinesInput = "";
        protected string companyChoiceUserInput = "";
        protected int vType = 0;
        protected int cType = 0;
        protected int mType = 0;
        protected string[] twoWheelerCompanyChoices = new string[10];
        protected string[] twoWheelerTypeChoices = new string[10];
        protected long[] twoWheelerDistributors = new long[20];
        protected string modelChoiceUserInput = "";
        protected long distributorCommissionPercentage = 0;
        protected long bestPrice = 0;
        protected string twowheelerDistributorsChoiceInput = "";
        protected string twoWheelerModelName = "";
        protected long minimumDistributorPercentage;
        protected int distributorCount = 0;
        public void TwoWheelerType()
        {
            twoWheelerTypeChoices[0] = "scooty";
            twoWheelerTypeChoices[1] = "bikes";
            // TVS : Scooty
            this.twoWheelerModelChoices[0] = "jupiter";
            this.twoWheelerModelChoices[1] = "scooty pep";
            this.twoWheelerModelChoices[2] = "ntorq";
            this.twoWheelerModelChoices[3] = "scooty zest";
            // Scooty Prices
            this.twoWheelerModelPrices[0] = "85000";
            this.twoWheelerModelPrices[1] = "54000";
            this.twoWheelerModelPrices[2] = "72000";
            this.twoWheelerModelPrices[3] = "62000";



            // Honda : Scooty
            this.twoWheelerModelChoices[4] = "activa 6g";
            this.twoWheelerModelChoices[5] = "dio";
            this.twoWheelerModelChoices[6] = "nitro";
            this.twoWheelerModelChoices[7] = "activa 125";
            // Scooty Prices
            this.twoWheelerModelPrices[4] = "85000";
            this.twoWheelerModelPrices[5] = "54000";
            this.twoWheelerModelPrices[6] = "72000";
            this.twoWheelerModelPrices[7] = "98000";

            // Hero : Scooty
            this.twoWheelerModelChoices[8] = "maestro";
            this.twoWheelerModelChoices[9] = "maestro edge";
            this.twoWheelerModelChoices[10] = "xoom";
            this.twoWheelerModelChoices[11] = "pleasure";
            // Scooty Prices
            this.twoWheelerModelPrices[8] = "85000";
            this.twoWheelerModelPrices[9] = "64000";
            this.twoWheelerModelPrices[10] = "62000";
            this.twoWheelerModelPrices[11] = "77000";



            // TVS : Bikes
            this.twoWheelerModelChoices[12] = "apache";
            this.twoWheelerModelChoices[13] = "sport";
            this.twoWheelerModelChoices[14] = "ronin";
            this.twoWheelerModelChoices[15] = "star city";
            // Bike Prices
            this.twoWheelerModelPrices[12] = "85500";
            this.twoWheelerModelPrices[13] = "64000";
            this.twoWheelerModelPrices[14] = "62000";
            this.twoWheelerModelPrices[15] = "77000";

            // Honda : Bikes
            this.twoWheelerModelChoices[16] = "shine";
            this.twoWheelerModelChoices[17] = "hornet";
            this.twoWheelerModelChoices[18] = "unicorn";
            this.twoWheelerModelChoices[19] = "sp";
            // Bike Prices
            this.twoWheelerModelPrices[16] = "83000";
            this.twoWheelerModelPrices[17] = "66000";
            this.twoWheelerModelPrices[18] = "69000";
            this.twoWheelerModelPrices[19] = "77500";

            // Bajaj : Bikes
            this.twoWheelerModelChoices[20] = "pulsar";
            this.twoWheelerModelChoices[21] = "dominar";
            this.twoWheelerModelChoices[22] = "platina";
            this.twoWheelerModelChoices[23] = "discovery";
            // Bike Prices
            this.twoWheelerModelPrices[20] = "93000";
            this.twoWheelerModelPrices[21] = "76000";
            this.twoWheelerModelPrices[22] = "89000";
            this.twoWheelerModelPrices[23] = "83500";




            Console.Write("\n1. Scooty\n2. Bike\n\nChoose the Two Wheeler Vehicle Type: ");
        twoWheelerTypeInputCheck:
            twoWheelerTypeInput = Console.ReadLine().ToLower();

            if (twoWheelerTypeInput == "scooty")
            {
                TwoWheelerCompany();
            }
            else if (twoWheelerTypeInput == "bike" || twoWheelerTypeInput == "bikes")
            {
                TwoWheelerCompany();
            }
            else
            {
                Console.Write("\n1. Scooty\n2. Bike\n\nChoose the Correct Two Wheeler Vehicle Type: ");
                goto twoWheelerTypeInputCheck;
            }
        }

        public void TwoWheelerCompany()
        {
            // Scooty Companies : This pattern is same followed for 
            twoWheelerCompanyChoices[0] = "tvs";
            twoWheelerCompanyChoices[1] = "honda";
            twoWheelerCompanyChoices[2] = "hero";



            // Bike Companies
            twoWheelerCompanyChoices[3] = "bajaj";
            // twoWheelerModelChoices[0] = "tvs";
            // twoWheelerModelChoices[0] = "honda";
            // twoWheelerModelChoices= "bajaj";

            if (twoWheelerTypeInput == "scooty")
            {
                for (vType = 0; vType < 1; vType++)
                {
                    for (cType = 0; cType < 3; cType++)
                    {
                        Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\n", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType]);
                    }
                }
                Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Company: ");
            scootyCompanyChoiceUserInputChecker:
                companyChoiceUserInput = Console.ReadLine().ToLower();
                if (companyChoiceUserInput == "tvs" || companyChoiceUserInput == "honda" || companyChoiceUserInput == "bajaj")
                {
                    TwoWheelerModels();
                }
                else
                {
                    Console.Write("Invalid Company Option Entered..!\n\nChoose the Two Wheeler Vehicle Company: ");
                    goto scootyCompanyChoiceUserInputChecker;
                }
            }
            else if (twoWheelerTypeInput == "bike" || twoWheelerTypeInput == "bikes")
            {
                for (vType = 1; vType < 2; vType++)
                {
                    for (cType = 0; cType < 4; cType++)
                    {
                        if (cType == 2)
                        {
                            continue;
                        }
                        Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\n", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType]);
                    }
                }
                Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Company: ");
            bikeCompanyChoiceUserInputChecker:
                companyChoiceUserInput = Console.ReadLine().ToLower();
                if (companyChoiceUserInput == "tvs" || companyChoiceUserInput == "honda" || companyChoiceUserInput == "bajaj")
                {
                    TwoWheelerModels();
                }
                else
                {
                    Console.Write("Invalid Company Option Entered..!\n\nChoose the Two Wheeler Vehicle Company: ");
                    goto bikeCompanyChoiceUserInputChecker;
                }
            }

        }
        public void TwoWheelerModels()
        {
            
            if (twoWheelerTypeInput == "scooty")
            {
                if (companyChoiceUserInput == "tvs")
                {
                    for (vType = 0; vType < 1; vType++)
                    {
                        for (cType = 0; cType < 1; cType++)
                        {
                            for (mType = 0; mType < 4; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType], twoWheelerModelChoices[mType], twoWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Two Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();

                }
                else if (companyChoiceUserInput == "honda")
                {
                    for (vType = 0; vType < 1; vType++)
                    {
                        for (cType = 1; cType < 2; cType++)
                        {
                            for (mType = 4; mType < 8; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType], twoWheelerModelChoices[mType], twoWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Two Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }
                else if (companyChoiceUserInput == "hero")
                {
                    for (vType = 0; vType < 1; vType++)
                    {
                        for (cType = 2; cType < 3; cType++)
                        {
                            for (mType = 8; mType < 12; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType], twoWheelerModelChoices[mType], twoWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Two Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }
             
            }

            else if (twoWheelerTypeInput == "bike" || twoWheelerTypeInput == "bikes")
            {
                if (companyChoiceUserInput == "tvs")
                {
                    for (vType = 1; vType < 2; vType++)
                    {
                        for (cType = 0; cType < 1; cType++)
                        {
                            for (mType = 12; mType < 16; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType], twoWheelerModelChoices[mType], twoWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Two Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }

                else if (companyChoiceUserInput == "honda")
                {
                    for (vType = 1; vType < 2; vType++)
                    {
                        for (cType = 1; cType < 2; cType++)
                        {
                            for (mType = 16; mType < 20; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType], twoWheelerModelChoices[mType], twoWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Two Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }

                else if (companyChoiceUserInput == "bajaj")
                {
                    for (vType = 1; vType < 2; vType++)
                    {
                        for (cType = 3; cType < 4; cType++)
                        {
                            for (mType = 20; mType < 24; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType], twoWheelerModelChoices[mType], twoWheelerModelPrices[mType]);
                            }
                        }
                    }

                    Console.WriteLine("\n\nThis Two Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Two Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }
                
            }
            foreach (string o in twoWheelerModelChoices)
            {
                if (o == modelChoiceUserInput)
                {
                    for (mType = 0; mType < 24; mType++)
                    {
                        if (twoWheelerModelChoices[mType] == modelChoiceUserInput)
                        {
                            cType--;
                            vType--;
                            modelType = twoWheelerModelChoices[mType];
                            Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", twoWheelerTypeChoices[vType], twoWheelerCompanyChoices[cType], twoWheelerModelChoices[mType], twoWheelerModelPrices[mType]);
                            TwoWheelerDistributor();
                            
                        }
                        
                    }
                }
                
            }

            if (modelChoiceUserInput != modelType)
            {
                Console.WriteLine("\n\nInvalid Model Name Choosen..!\n\nEnter Correct Option:");
                TwoWheelerModels();
            }
            Console.ReadKey();
        }
       
        public void TwoWheelerDistributor()
        {

            if (companyChoiceUserInput == "tvs")
            {
                twoWheelerDistributors[0] = 7;
                twoWheelerDistributors[1] = 11;
                twoWheelerDistributors[2] = 9;
                twoWheelerDistributors[3] = 8;
                twoWheelerDistributors[4] = 6;
                Console.WriteLine("Distributors Commission Percentages:");
                
                distributorCount = 1;
                minimumDistributorPercentage = twoWheelerDistributors[0];
                for (long k = 0; k < 5; k++)
                {
                    if (twoWheelerDistributors[k] < minimumDistributorPercentage)
                    {
                        minimumDistributorPercentage = twoWheelerDistributors[k];
                    }
                    Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, twoWheelerDistributors[k]);
                
                    distributorCount++;
                }
                
                twoWheelerBestPriceCalculator(twoWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
            }
            else if (companyChoiceUserInput == "honda")
            {
                twoWheelerDistributors[5] = 8;
                twoWheelerDistributors[6] = 5;
                twoWheelerDistributors[7] = 7;
                twoWheelerDistributors[8] = 10;
                twoWheelerDistributors[9] = 9;
                Console.WriteLine("Distributors Commission Percentages:");
                
                distributorCount = 1;
                minimumDistributorPercentage = twoWheelerDistributors[5];
                for (long k = 5; k < 10; k++)
                {
                    if (twoWheelerDistributors[k] < minimumDistributorPercentage)
                    {
                        minimumDistributorPercentage = twoWheelerDistributors[k];
                    }
                    Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, twoWheelerDistributors[k]);
                    distributorCount++;
                
                }
                
                twoWheelerBestPriceCalculator(twoWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
            }
            else if (companyChoiceUserInput == "hero")
            {
                twoWheelerDistributors[10] = 8;
                twoWheelerDistributors[11] = 5;
                twoWheelerDistributors[12] = 7;
                twoWheelerDistributors[13] = 10;
                Console.WriteLine("Distributors Commission Percentages:");
                distributorCount = 1;
                minimumDistributorPercentage = twoWheelerDistributors[10];
                for (long k = 10;k < 14;k++)
                {
                    if (twoWheelerDistributors[k] < minimumDistributorPercentage)
                    {
                        minimumDistributorPercentage = twoWheelerDistributors[k];
                    }
                    Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, twoWheelerDistributors[k]);
                    distributorCount++;
                
                }
                
                twoWheelerBestPriceCalculator(twoWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
            }
            else if (companyChoiceUserInput == "bajaj")
            {
                twoWheelerDistributors[14] = 6;
                twoWheelerDistributors[15] = 7;
                twoWheelerDistributors[16] = 11;
                twoWheelerDistributors[17] = 10;
                Console.WriteLine("Distributors Commission Percentages:");
                minimumDistributorPercentage = twoWheelerDistributors[14];
                distributorCount = 1;
                for (long k = 14; k < 18; k++)
                {
                    if (twoWheelerDistributors[k] < minimumDistributorPercentage)
                    {
                        minimumDistributorPercentage = twoWheelerDistributors[k];
                    }
                    Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, twoWheelerDistributors[k]);
                    distributorCount++;
                
                }
                
                
                twoWheelerBestPriceCalculator(twoWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
            }

        }
        public void twoWheelerBestPriceCalculator(string twoWheelerBasePrice,string twoWheelerModelName, long distributorCommissionPercentage) 
        {
            long distributorCommission = ((long)(Convert.ToInt32(twoWheelerBasePrice) * (Convert.ToDouble(distributorCommissionPercentage)* 0.01)));
            Console.WriteLine("Distributor Minimum Commission Percentage: {0}",distributorCommissionPercentage);
            Console.WriteLine("Distributor Minimum Commission Amount: {0}",distributorCommission);


            bestPrice = distributorCommission + Convert.ToInt64(twoWheelerBasePrice);

            Console.WriteLine("\n\nThe Choosen Vehicle {0} Best On Road Price: {1}\n",twoWheelerModelName, bestPrice);
            
        }
     
    }
    
    public interface TwoWheeler
    {
        public void TwoWheelerType();
        public void TwoWheelerCompany();
        public void TwoWheelerModels();
        public void TwoWheelerDistributor();
        
    }

}