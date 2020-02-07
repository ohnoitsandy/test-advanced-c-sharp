using System.Runtime.InteropServices;
using System.Text;
using static System.Console;

namespace CoreTest.Utilities
{
  public static class UiPainter
  {
    public static void PaintMainUi()
    {
      PaintTitle("USER MANAGEMENT SYSTEM");
      PaintTitle("CHOOSE WHAT TO DO");
      WriteLine("1: ADD\n2: EDIT\n3: DELETE\n4: SEARCH\n5: EXIT");
    }

    private static void PaintTitle(string title)
    {
      var fixedSize = title.Length + 18;
      PaintLine(fixedSize);
      WriteLine($"-------- {title.ToUpper()} ----------");
    }

    private static void PaintLine(int fixedSize = 10)
    {
      var line = "".PadLeft(fixedSize, '-');
      WriteLine($"*{line}*");
    }

    public static void PaintAddTitle()
    {
      PaintTitle("ADD A NEW USER");
    }
    public static void PaintAddFirstName()
    {
      WriteLine("INPUT USERS FORENAME");
    }

    public static void PaintAddLastName()
    {
      PaintAddTitle();
      WriteLine("INPUT USERS LAST NAME");
    }

    public static void PaintAddMoLastName()
    {
      PaintAddTitle();
      WriteLine("INPUT USERS MOTHERS LAST NAME");
    }
    
    public static void PaintAddBirthDate()
    {
      PaintAddTitle();
      WriteLine("INPUT USERS BIRTHDATE MM/DD/YYYY");
    }

    public static void PaintSetMaStatus()
    {
      PaintAddTitle();
      WriteLine("SELECT A MARITAL STATUS");
      WriteLine("1: SINGLE\n2: MARRIED");
    }
    
    public static void PaintSetBloodType()
    {
      PaintAddTitle();
      WriteLine("SELECT A BLOOD TYPE");
      WriteLine("1: ORH+\n2: ORH-\n3: BRH+\n4: BRH-\n5: ARH+\n6: ARH-\n7: ABRH+\n8: ABRH-");
    }
    
    public static void PaintSetGender()
    {
      PaintAddTitle();
      WriteLine("SELECT GENDER");
      WriteLine("1: FEMALE\n2: MALE\n3: NONBINARY");
    }
    
    public static void PaintEdit()
    {
      PaintTitle("EDIT A USER");
      WriteLine("INPUT ANY USER DATA");
    }

    public static void PaintDelete()
    {
      PaintTitle("DELETE A USER");
      WriteLine("INPUT USER NAME");
    }

    public static void PaintSearch()
    {
      PaintTitle("SEARCH A USER");
      WriteLine("INPUT USER NAME");
    }
  }
}
