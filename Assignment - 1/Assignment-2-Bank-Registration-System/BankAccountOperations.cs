using System.Text.RegularExpressions;

namespace Assignment_2_Bank_Registration_System
{
    public class InsufficientBalanceException: Exception
    {
        public InsufficientBalanceException() 
        {
            Console.WriteLine("Insufficient Account Balance...!\n");
        }
    }
    public class BelowZeroValueException : Exception
    {
        public BelowZeroValueException()
        {
            Console.WriteLine("Below Zero Amount Value Is Not Allowed...!\n");
        }
    }
    public class FieldNullValueException : Exception
    {
        public FieldNullValueException()
        {
            Console.WriteLine("The Field Should Not Be Null...!\n");
        }
    }
    public class AboveDepositAmountLimitException : Exception
    {
        public AboveDepositAmountLimitException()
        {
            Console.WriteLine("Entered Above Daily Deposit Amount Limit...!\n");
        }
    }
    public class AboveWithdrawAmountLimitException : Exception
    {
        public AboveWithdrawAmountLimitException()
        {
            Console.WriteLine("Entered Above Daily Withdraw Amount Limit...!\n");
        }
    }
    public class DepositAccessLimitException : Exception
    {
        public DepositAccessLimitException()
        {
            Console.WriteLine("Daily Deposit Access Limit Crossed...!\n");
        }
    }

    public class WithdrawAccessLimitException : Exception
    {
        public WithdrawAccessLimitException()
        {
            Console.WriteLine("Daily Withdraw Access Limit Crossed...!\n");
        }
    }
    public class WrongAccountDetailsException : Exception
    {
        public WrongAccountDetailsException()
        {
            Console.WriteLine("Entered Wrong Account Details...!\n");
        }
    }
    public class WrongInputDetailsException : Exception
    {
        public WrongInputDetailsException()
        {
            Console.WriteLine("Entered Wrong Input Details...!\n\nInput Field Value Should be Numeric..!\n");
        }
    }
    
    internal class BankAccountOperations: AllUserDetails
    {
        internal Regex regexForOnlyNumber = new Regex(@"[\d]$");
        internal long userDepositAmount;
        internal long userWithdrawAmount;
        internal int userEnteredAccountPin = 0;
        internal int depositAccessCount = 0;
        internal int WithdrawAccessCount = 0;
        internal int WrongAccountCount = 0;
        internal long depositDailyAmountCount = 0;
        internal long userEnteredAccountNumber = 0;
        internal long withdrawDailyAmountCount = 0;
        internal void BankAccountOperationsFunction()
        {
            try
            {
                string accountOperationsInputStatus = "";
                string accountOperationsStatus = "no";
                string AccountOperationUserChoice = "";
                
                Console.Write("\n\nDo You Want to Use Bank Operations Now to Deposit or Withdraw to Your Account(yes/no):");
            bankOperationsStatusChecker:
                accountOperationsInputStatus = Console.ReadLine().ToLower();
                accountOperationsStatus = accountOperationsInputStatus;
                if (accountOperationsStatus == "no" || accountOperationsStatus == "yes" || accountOperationsStatus == "y" || accountOperationsStatus == "n")
                {
                    while (accountOperationsStatus == "yes")
                    {
                        if (accountOperationsInputStatus == "yes" || accountOperationsInputStatus == "y")
                        {
                            accountOperationsStatus = "yes";
                            Console.Write("\n\nEnter the  (Deposit or Withdraw):");
                            AccountOperationUserChoice = Console.ReadLine().ToLower();
                            if (AccountOperationUserChoice == "deposit")
                            {
                                DepositFunction();
                                Console.Write("\n\nDo You Want to Use Bank Operations Now to Deposit or Withdraw to Your Account(yes/no):");
                                goto bankOperationsStatusChecker;
                                depositAccessCount++;
                            }
                            else if (AccountOperationUserChoice == "withdraw")
                            {
                                WithdrawFunction();
                                Console.Write("\n\nDo You Want to Use Bank Operations Now to Deposit or Withdraw to Your Account(yes/no):");
                                goto bankOperationsStatusChecker;
                                WithdrawAccessCount++;
                            }
                            else
                            {
                                accountOperationsInputStatus = "no";
                                Console.WriteLine("Entered Invalid Options..!");
                                break;
                            }
                        }
                        else if (accountOperationsInputStatus == "No" || accountOperationsInputStatus == "No" || accountOperationsInputStatus == "N" || accountOperationsInputStatus == "n")
                        {

                            accountOperationsStatus = "no";
                            break;
                        }
                    }
                }
            }
            catch (InsufficientBalanceException e1)
            {

                Console.WriteLine(e1.Message);

            }

            catch (DepositAccessLimitException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (WithdrawAccessLimitException e5)
            {

                Console.WriteLine(e5.Message);

            }
            catch (BelowZeroValueException e6)
            {
                Console.WriteLine(e6.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write("\n\n+++++-------Thank You For Using Our Bank-------+++++");
            }
        }

        internal void DepositFunction()
        {
            try
            {
                userDepositAmount= 0;
                depositAccessCount++;
                Console.Write("\n\nEnter the Deposit Amount:");
                string userDepositAmount1 = Console.ReadLine();

                
                if (userDepositAmount1 == null || Convert.ToInt64(userDepositAmount1) == 0)
                {
                    throw new FieldNullValueException();
                }
                if (!(regexForOnlyNumber.IsMatch(userDepositAmount1)))
                {
                    throw new WrongInputDetailsException();
                }
                userDepositAmount = Convert.ToInt64(userDepositAmount1);
                Console.WriteLine(userDepositAmount);
                if (userDepositAmount >= 100000)
                {
                    throw new AboveDepositAmountLimitException();
                }
                else if (userDepositAmount < 0)
                {
                    throw new BelowZeroValueException();
                }
                else if(depositAccessCount == 4)
                {
                    throw new DepositAccessLimitException();
                }
                else
                {
                    Console.Write("\n\nEnter Bank Account Number:");
                    userEnteredAccountNumber = Convert.ToInt64(Console.ReadLine());
                    Console.Write("\n\nEnter Bank Account PIN Number:");
                    userEnteredAccountPin = Convert.ToInt16(Console.ReadLine());
                    if (base.accountNumber == userEnteredAccountNumber && base.accountPinNumber == userEnteredAccountPin)
                    {
                        depositDailyAmountCount += userDepositAmount;
                        if (depositDailyAmountCount > 100000)
                        {
                            throw new AboveDepositAmountLimitException();
                        }
                        else
                        {
                            base.accountBalance += userDepositAmount;
                            Console.WriteLine("\n\n-+-+-+-+-+-+-+-+BANK PAYMENT DETAILS-+-+-+-+-+-+-+-+");
                            Console.WriteLine("\n\nAmount {0} Deposited Successfully...!", userDepositAmount);
                            Console.WriteLine("Current Account Balance: {0}", base.accountBalance);
                        }
                    }
                    else
                    {
                        throw new WrongAccountDetailsException();
                    }
                    
                    
                }
            }
            catch (AboveDepositAmountLimitException e2)
            {

                Console.WriteLine(e2.Message);

            }
            catch (WrongAccountDetailsException e3)
            {

                Console.WriteLine(e3.Message);

            }
            catch (DepositAccessLimitException e4)
            {

                Console.WriteLine(e4.Message);
 
            }
            catch (BelowZeroValueException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (FieldNullValueException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (WrongInputDetailsException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        internal void WithdrawFunction()
        {
            try
            {
                userWithdrawAmount= 0;
                Console.Write("\n\nEnter the Withdraw Amount:");
                string userWithdrawAmount1 = Console.ReadLine();
                WithdrawAccessCount++;

                if (userWithdrawAmount1 == null || Convert.ToInt64(userWithdrawAmount1) == 0)
                {
                    throw new FieldNullValueException();
                }
                if (!(regexForOnlyNumber.IsMatch(userWithdrawAmount1)))
                {
                    throw new WrongInputDetailsException();
                }
                else
                {
                    userWithdrawAmount = Convert.ToInt64(userWithdrawAmount1);
                }
                if (userWithdrawAmount > 20000)
                {
                    throw new AboveWithdrawAmountLimitException();
                }
                else if (userWithdrawAmount < 0)
                {
                    throw new BelowZeroValueException();
                }
                else if(WithdrawAccessCount == 4)
                {
                    throw new WithdrawAccessLimitException();
                }
                else if(base.accountBalance < userWithdrawAmount)
                {
                    throw new InsufficientBalanceException();
                }
                else
                {
                    Console.Write("\n\nEnter Bank Account Number:");
                    userEnteredAccountNumber = Convert.ToInt64(Console.ReadLine());
                    Console.Write("\n\nEnter Bank Account PIN Number:");
                    userEnteredAccountPin = Convert.ToInt16(Console.ReadLine());
                    if (base.accountNumber == userEnteredAccountNumber && base.accountPinNumber == userEnteredAccountPin)
                    {
                        withdrawDailyAmountCount += userWithdrawAmount;
                        if (withdrawDailyAmountCount > 20000)
                        {
                            throw new AboveWithdrawAmountLimitException();
                        }
                        else
                        {
                            base.accountBalance -= userWithdrawAmount;
                            Console.WriteLine("\n\n-+-+-+-+-+-+-+-+BANK PAYMENT DETAILS+-+-+-+-+-+-+-+-");
                            Console.WriteLine("\nAmount {0} Withdrawed Successfully...!", userWithdrawAmount);
                            Console.WriteLine("\nCurrent Account Balance: {0}", base.accountBalance);
                        }
                    }
                    else
                    {
                        throw new WrongAccountDetailsException();
                    }

                }
            }
            
            catch (AboveWithdrawAmountLimitException e2)
            {

                Console.WriteLine(e2.Message);

            }
            catch (WrongAccountDetailsException e3)
            {

                Console.WriteLine(e3.Message);

            }
            catch (WithdrawAccessLimitException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (BelowZeroValueException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (FieldNullValueException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (WrongInputDetailsException e4)
            {

                Console.WriteLine(e4.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
