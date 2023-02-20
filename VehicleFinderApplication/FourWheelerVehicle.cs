
namespace VehicleFinder
{	

public class FourWheelerVehicle : FourWheeler
    {
        protected string modelType = "";
        protected long distributorCommission = 0;
        protected string[] fourWheelerModelChoices = new string[100];
        protected string[] fourWheelerModelPrices = new string[100];
        protected string fourWheelerTypeInput = "";
        protected string fourWheelerCompinesInput = "";
        protected string companyChoiceUserInput = "";
        protected int vType = 0;
        protected int cType = 0;
        protected int mType = 0;
        protected string[] fourWheelerCompanyChoices = new string[10];
        protected string[] fourWheelerTypeChoices = new string[10];
        protected long[] fourWheelerDistributors = new long[20];
        protected string modelChoiceUserInput = "";
        protected long distributorCommissionPercentage = 0;
        protected long bestPrice = 0;
        protected string fourwheelerDistributorsChoiceInput = "";
        protected string fourWheelerModelName = "";
        protected long minimumDistributorPercentage;
        protected int distributorCount = 0;


        public void FourWheelerType()
        {
            fourWheelerTypeChoices[0] = "hatchback";
            fourWheelerTypeChoices[1] = "sedans";
            
            // Suzuki : Hatchback
            this.fourWheelerModelChoices[0] = "baleno";
            this.fourWheelerModelChoices[1] = "celerio";
            this.fourWheelerModelChoices[2] = "shift";
            this.fourWheelerModelChoices[3] = "ignis";
            // Hatchback Prices
            this.fourWheelerModelPrices[0] = "1285000";
            this.fourWheelerModelPrices[1] = "854000";
            this.fourWheelerModelPrices[2] = "972000";
            this.fourWheelerModelPrices[3] = "862000";


            // hundai : Hatchback
            this.fourWheelerModelChoices[4] = "i10 grand";
            this.fourWheelerModelChoices[5] = "kappa";
            this.fourWheelerModelChoices[6] = "i10";
            this.fourWheelerModelChoices[7] = "i20";
            // Hatchback Prices
            this.fourWheelerModelPrices[4] = "835000";
            this.fourWheelerModelPrices[5] = "954000";
            this.fourWheelerModelPrices[6] = "772000";
            this.fourWheelerModelPrices[7] = "1198000";

            // Toyota : Hatchback
            this.fourWheelerModelChoices[8] = "corolla";
            this.fourWheelerModelChoices[9] = "glanza";
            this.fourWheelerModelChoices[10] = "etios";
            this.fourWheelerModelChoices[11] = "tundra";
            // Hatchback Prices
            this.fourWheelerModelPrices[8] = "1285000";
            this.fourWheelerModelPrices[9] = "664000";
            this.fourWheelerModelPrices[10] = "862000";
            this.fourWheelerModelPrices[11] = "1227000";


            // Suzuki : Sedans
            this.fourWheelerModelChoices[12] = "dzire";
            this.fourWheelerModelChoices[13] = "ciaz";
            this.fourWheelerModelChoices[14] = "sx4";
            this.fourWheelerModelChoices[15] = "scross";
            // Sedan Prices
            this.fourWheelerModelPrices[12] = "825500";
            this.fourWheelerModelPrices[13] = "1324000";
            this.fourWheelerModelPrices[14] = "854000";
            this.fourWheelerModelPrices[15] = "677000";

            // hundai : Sedans
            this.fourWheelerModelChoices[16] = "elantra";
            this.fourWheelerModelChoices[17] = "verna";
            this.fourWheelerModelChoices[18] = "sonata";
            this.fourWheelerModelChoices[19] = "accent";
            // Sedan Prices
            this.fourWheelerModelPrices[16] = "1453000";
            this.fourWheelerModelPrices[17] = "1266000";
            this.fourWheelerModelPrices[18] = "1869000";
            this.fourWheelerModelPrices[19] = "967500";

            // Honda : Sedans
            this.fourWheelerModelChoices[20] = "city";
            this.fourWheelerModelChoices[21] = "accord";
            this.fourWheelerModelChoices[22] = "civic";
            this.fourWheelerModelChoices[23] = "amaze";
            // Sedan Prices
            this.fourWheelerModelPrices[20] = "1293000";
            this.fourWheelerModelPrices[21] = "886000";
            this.fourWheelerModelPrices[22] = "1129000";
            this.fourWheelerModelPrices[23] = "883500";




            Console.Write("\n1. Hatchback\n2. Sedan\n\nChoose the Four Wheeler Vehicle Type: ");
        fourWheelerTypeInputCheck:
            fourWheelerTypeInput = Console.ReadLine().ToLower();

            if (fourWheelerTypeInput == "hatchback")
            {
                FourWheelerCompany();
            }
            else if (fourWheelerTypeInput == "sedan" || fourWheelerTypeInput == "sedans")
            {
                FourWheelerCompany();
            }
            else
            {
                Console.Write("\n1. Hatchback\n2. Sedan\n\nChoose the Correct Four Wheeler Vehicle Type: ");
                goto fourWheelerTypeInputCheck;
            }
        }

		public void FourWheelerCompany()
        {
            // Hatchback Companies : This pattern is same followed for 
            fourWheelerCompanyChoices[0] = "suzuki";
            fourWheelerCompanyChoices[1] = "hundai";
            fourWheelerCompanyChoices[2] = "toyota";



            // Sedan Companies
            fourWheelerCompanyChoices[3] = "honda";
            // fourWheelerModelChoices[0] = "suzuki";
            // fourWheelerModelChoices[0] = "hundai";
            // fourWheelerModelChoices= "honda";

            if (fourWheelerTypeInput == "hatchback")
            {
                for (vType = 0; vType < 1; vType++)
                {
                    for (cType = 0; cType < 3; cType++)
                    {
                        Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\n", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType]);
                    }
                }
                Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Company: ");
                hatchbackCompanyChoiceUserInputChecker:
                companyChoiceUserInput = Console.ReadLine().ToLower();


                if (companyChoiceUserInput == "hundai" || companyChoiceUserInput == "suzuki" || companyChoiceUserInput == "toyota")
                {
                    FourWheelerModels();
                }
                else
                {
                    Console.Write("Invalid Company Option Entered..!\n\nChoose the Four Wheeler Vehicle Company: ");
                    goto hatchbackCompanyChoiceUserInputChecker;
                }
            }
            else if (fourWheelerTypeInput == "sedan" || fourWheelerTypeInput == "sedans")
            {
                for (vType = 1; vType < 2; vType++)
                {
                    for (cType = 0; cType < 4; cType++)
                    {
                        if (cType == 2)
                        {
                            continue;
                        }
                        Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\n", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType]);
                    }
                }

                Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Company: ");
                sedanCompanyChoiceUserInputChecker:
                companyChoiceUserInput = Console.ReadLine().ToLower();

            if(companyChoiceUserInput == "honda" || companyChoiceUserInput == "suzuki" || companyChoiceUserInput == "hundai")
                {
                    FourWheelerModels();
                }
                else
                {
                    Console.Write("Invalid Company Option Entered..!\n\nChoose the Four Wheeler Vehicle Company: ");
                    goto sedanCompanyChoiceUserInputChecker;
                }
                
            }
            
        }
		public void FourWheelerModels()
        {
            if (fourWheelerTypeInput == "hatchback")
            {
                if (companyChoiceUserInput == "suzuki")
                {
                    for (vType = 0; vType < 1; vType++)
                    {
                        for (cType = 0; cType < 1; cType++)
                        {
                            for (mType = 0; mType < 4; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType], fourWheelerModelChoices[mType], fourWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Four Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();

                }
                else if (companyChoiceUserInput == "hundai")
                {
                    for (vType = 0; vType < 1; vType++)
                    {
                        for (cType = 1; cType < 2; cType++)
                        {
                            for (mType = 4; mType < 8; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType], fourWheelerModelChoices[mType], fourWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Four Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }
                else if (companyChoiceUserInput == "toyota")
                {
                    for (vType = 0; vType < 1; vType++)
                    {
                        for (cType = 2; cType < 3; cType++)
                        {
                            for (mType = 8; mType < 12; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType], fourWheelerModelChoices[mType], fourWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Four Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                    
                }
            }

            else if (fourWheelerTypeInput == "sedan" || fourWheelerTypeInput == "sedans")
            {
                if (companyChoiceUserInput == "suzuki")
                {
                    for (vType = 1; vType < 2; vType++)
                    {
                        for (cType = 0; cType < 1; cType++)
                        {
                            for (mType = 12; mType < 16; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType], fourWheelerModelChoices[mType], fourWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Four Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }

                else if (companyChoiceUserInput == "hundai")
                {
                    for (vType = 1; vType < 2; vType++)
                    {
                        for (cType = 1; cType < 2; cType++)
                        {
                            for (mType = 16; mType < 20; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType], fourWheelerModelChoices[mType], fourWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Four Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");
                    Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();
                }

                else if (companyChoiceUserInput == "honda")
                {
                    for (vType = 1; vType < 2; vType++)
                    {
                        for (cType = 3; cType < 4; cType++)
                        {
                            for (mType = 20; mType < 24; mType++)
                            {
                                Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType], fourWheelerModelChoices[mType], fourWheelerModelPrices[mType]);
                            }
                        }
                    }
                    Console.WriteLine("\n\nThis Four Wheeler Vehicle Model Price excludes Vehicle Distributors charge...!\n");

                    Console.WriteLine("\n\nChoose the Four Wheeler Vehicle Model: ");
                    modelChoiceUserInput = Console.ReadLine().ToLower();


                }
                
            }
            foreach (string o in fourWheelerModelChoices)
            {
                if (o == modelChoiceUserInput)
                {
                    for (mType = 0; mType < 24; mType++)
                    {
                        if (fourWheelerModelChoices[mType] == modelChoiceUserInput)
                        {
                            cType--;
                            vType--;
                            modelType = fourWheelerModelChoices[mType];
                            Console.WriteLine("\nVehicle Type: {0}\nVehicle Company: {1}\nModel Name: {2}\nModel Price: {3}", fourWheelerTypeChoices[vType], fourWheelerCompanyChoices[cType], fourWheelerModelChoices[mType], fourWheelerModelPrices[mType]);
                            FourWheelerDistributor();
                        }

                    }
                }
            }
            if (modelChoiceUserInput != modelType)
            {
                Console.WriteLine("\n\nInvalid Model Name Choosen..!\n\nEnter Correct Option:");
                FourWheelerModels();
            }
            Console.ReadKey();
        }
    public void FourWheelerDistributor()
    {


        if (companyChoiceUserInput == "suzuki")
        {
            fourWheelerDistributors[0] = 7;
            fourWheelerDistributors[1] = 11;
            fourWheelerDistributors[2] = 9;
            fourWheelerDistributors[3] = 8;
            fourWheelerDistributors[4] = 6;
            Console.WriteLine("Distributors Commission Percentages:");

            distributorCount = 1;
            minimumDistributorPercentage = fourWheelerDistributors[0];
            for (long k = 0; k < 5; k++)
            {
                if (fourWheelerDistributors[k] < minimumDistributorPercentage)
                {
                    minimumDistributorPercentage = fourWheelerDistributors[k];
                }
                Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, fourWheelerDistributors[k]);

                distributorCount++;
            }

            fourWheelerBestPriceCalculator(fourWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
        }
        else if (companyChoiceUserInput == "hundai")
        {
            fourWheelerDistributors[5] = 8;
            fourWheelerDistributors[6] = 5;
            fourWheelerDistributors[7] = 7;
            fourWheelerDistributors[8] = 10;
            fourWheelerDistributors[9] = 9;
            Console.WriteLine("Distributors Commission Percentages:");

            distributorCount = 1;
            minimumDistributorPercentage = fourWheelerDistributors[5];
            for (long k = 5; k < 10; k++)
            {
                if (fourWheelerDistributors[k] < minimumDistributorPercentage)
                {
                    minimumDistributorPercentage = fourWheelerDistributors[k];
                }
                Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, fourWheelerDistributors[k]);
                distributorCount++;

            }

            fourWheelerBestPriceCalculator(fourWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
        }
        else if (companyChoiceUserInput == "toyota")
        {
            fourWheelerDistributors[10] = 8;
            fourWheelerDistributors[11] = 5;
            fourWheelerDistributors[12] = 7;
            fourWheelerDistributors[13] = 10;
            Console.WriteLine("Distributors Commission Percentages:");
            distributorCount = 1;
            minimumDistributorPercentage = fourWheelerDistributors[10];
            for (long k = 10; k < 14; k++)
            {
                if (fourWheelerDistributors[k] < minimumDistributorPercentage)
                {
                    minimumDistributorPercentage = fourWheelerDistributors[k];
                }
                Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, fourWheelerDistributors[k]);
                distributorCount++;

            }

            fourWheelerBestPriceCalculator(fourWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
        }
        else if (companyChoiceUserInput == "honda")
        {
            fourWheelerDistributors[14] = 6;
            fourWheelerDistributors[15] = 7;
            fourWheelerDistributors[16] = 11;
            fourWheelerDistributors[17] = 10;
            Console.WriteLine("Distributors Commission Percentages:");
            minimumDistributorPercentage = fourWheelerDistributors[14];
            distributorCount = 1;
            for (long k = 14; k < 18; k++)
            {
                if (fourWheelerDistributors[k] < minimumDistributorPercentage)
                {
                    minimumDistributorPercentage = fourWheelerDistributors[k];
                }
                Console.WriteLine("Distributors {0} Commission Percentage : {1}%", distributorCount, fourWheelerDistributors[k]);
                distributorCount++;

            }


            fourWheelerBestPriceCalculator(fourWheelerModelPrices[mType], modelChoiceUserInput, minimumDistributorPercentage);
        }

    }
    public void fourWheelerBestPriceCalculator(string fourWheelerBasePrice, string fourWheelerModelName, long distributorCommissionPercentage)
    {
        long distributorCommission = ((long)(Convert.ToInt32(fourWheelerBasePrice) * (Convert.ToDouble(distributorCommissionPercentage) * 0.01)));
        Console.WriteLine("Distributor Minimum Commission Percentage: {0}", distributorCommissionPercentage);
        Console.WriteLine("Distributor Minimum Commission Amount: {0}", distributorCommission);


        bestPrice = distributorCommission + Convert.ToInt64(fourWheelerBasePrice);

        Console.WriteLine("\n\nThe Choosen Vehicle {0} Best On Road Price: {1}\n", fourWheelerModelName, bestPrice);

    }

}

public interface FourWheeler
{
    public void FourWheelerType();
    public void FourWheelerCompany();
    public void FourWheelerModels();
    public void FourWheelerDistributor();
    

    }
}