/******************************************************************************
Amanda Rosado
Professor Clifford Brozo
Date: 3/5/2023
*******************************************************************************/

using System;

class Car {
  //*************G L O B A L    V A R I A B L E S*****************
    
  private int Speed;
  private char Gear;
  private bool is_Started;
  private bool lights_on;
    
  //*****************C A R    I N S T A N C E******************
  public Car()
  {
    Speed      = 0;
    Gear       = 'P';
    is_Started = false;
    lights_on  = false;
  }

  public int Accelerate(bool car_on, char PRD, int amount)
  {
    if(car_on)
    {
      if (PRD =='P')
      {
        Console.WriteLine("The Car is on, but you are still in Park!");
        Console.WriteLine(" Please put the car in DRIVE or REVERSE before stepping on the gas!");
      }
      else
      {
        Speed += amount;
        if (Speed >=55)
        {
          Console.WriteLine("********** YOU ARE S P E E D I N G *******");
          Console.WriteLine(" Your Current Speed is" + Speed + "MPH");
          Console.WriteLine("*********** S L O W     D O W N ***********");
        }
        else
        {
          Console.WriteLine("Going Faster!!! Your Current Speed is" + Speed + "MPH");
        }
      }
    }
    
    return Speed;
  }
  // Close Accelerate Function

  
  public int Brake(int amount)
  {
    if (Speed <=0)
    {
      Console.WriteLine("************** You Cannot Brake ***********");
      Console.WriteLine("************* The Car is already at  MPH ****");
    }
    else
    {
      Speed -= amount;
      Console.WriteLine("Slowing Down! Your Current Speed is" + Speed + "MPH");
    }  
    return Speed;
  }
  // Close Brake Function

  
  public void Message()
  {
    Console.WriteLine("Thank you for using our Car Simulator!");
  }
  // CLose Message Function

  
  public bool StartCar(bool car_on)
  {  
    if (car_on == true)
    {
       Console.WriteLine("The Car is already STARTED!");
    }    
    else
    {
      car_on =true;
      Console.WriteLine("The Car is STARTED!");
    }
    
    return car_on;
  }   
  //Close StartCar Function

  
  public bool TurnOff(bool car_on, int mph, char prd)
  {
    if (car_on)
    {
      if (mph !=0)
      {
        Console.WriteLine("The Car cannot be Turned OFF!");
        Console.WriteLine("It is moving at" + Speed + "MPH");
      }    
      else
      {
        if (prd !=0)
        {
          Console.WriteLine(" The Car MUST be in PARK to turn OFF!");
        }
        else
        {
          Console.WriteLine("The Car is NOW OFF!");
          car_on = false;
        }  
      }
    }
    
    return car_on;  
  }
  // Close TurnOff Function

  
  //********************** C H A N G E     G E A R S*******************
  public char ChangeGears(char  PRD, bool car_on) // PRD - Park Reverse Drive
  {
    if (car_on)
    {
      if (Speed !=0) {
        Console.WriteLine("********** You Cannot Change Gears *******");
        Console.WriteLine("********** The Car is moving at" + Speed + "MPH****");
        Console.WriteLine("********** You must brake until you are at 0 MPH  ******");
      }

      else
      {
        Console.WriteLine("");
        Console.WriteLine("**************************");
        Console.WriteLine("******** T R A N S M I S S I O N ***");
        Console.WriteLine("****** 1. Put the Car in Park ***");
        Console.WriteLine("****** 2. Put the Car in REVERSE ***");
        Console.WriteLine("****** 3. Put the Car in DRIVE ***");
        
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1 :PRD = 'P'; Console.WriteLine("The Car is now in PARK");   break;
          case 2 :PRD = 'R';Console.WriteLine("The Car is now in REVERSE"); break;
          case 3 :PRD = 'D'; Console.WriteLine("The Car is now in Drive");  break;
        } 
      //Close switch
      
      }     
      // Close else

    }
    // close if car_on   
    else
    {
      Console.WriteLine("********* You Cannot Change Gears ********");
      Console.WriteLine("********* The Car is Not Started  *****");
      Console.WriteLine("********* You must Start The Car before Changing Gears");
    }    
    // close else
    
    return PRD;
  }  
  // Close Change Gears Function
}

class Program {
  public static void Main (string[] args) {
    Car car         = new Car();
    bool is_running = true;
    bool is_Started = false;
    int Speed       = 0;
    char gear       = 'P';
    while (is_running) 
    {
      Console.WriteLine("");
      Console.WriteLine("**************************************");
      Console.WriteLine("***    C A R  S I M U L A T O R    ***");
      Console.WriteLine("***    1. START the CAR            ***");
      Console.WriteLine("***    2. Turn  the Car OFF        ***");
      Console.WriteLine("***    3. Change Gears             ***");
      Console.WriteLine("***    4. Step on The Gas          ***");
      Console.WriteLine("***    5. Step On The Brake        ***");
      Console.WriteLine("***    6. QUIT                     ***");
      int choice = int.Parse(Console.ReadLine());
      
      switch (choice)
      {
        case 1: is_Started = car.StartCar(is_Started);                break;
        case 2: is_Started = car.TurnOff(is_Started, Speed, gear);    break;
        case 3: gear       = car.ChangeGears(gear, is_Started);       break;
        case 4: Speed      = car.Accelerate(is_Started, gear, 10);    break;
        case 5: Speed      = car.Brake(10);                           break;
        case 6: is_running = false; 
                car.Message();                                        break;    
        default: Console.WriteLine("Invalid Choice. Try Again");      break;   
      } 
      // Close Switch
      
    }
    
  }  
}
