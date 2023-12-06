using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "abc";
        string expected = "cba";

        // Act
        string result=_exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input= null;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        //Arrange
        decimal totalPrice = 100;
        decimal discount = 10;
        decimal expected = 90;
        //Act
        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);
        //Assert
        Assert.AreEqual(expected, result);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = -10;

        //Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(()=>_exceptions.ArgumentCalculateDiscount(totalPrice,discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        //Arrange
        int[] num = { 1, 2, 3 };
        int index = 1;
        int expected = 2;
        //Act
        int result = _exceptions.IndexOutOfRangeGetElement(num, index);
        //Assert
        Assert.AreEqual(expected, result);
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] num = { 1, 2, 3 };
        int index = -1;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(num, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(()=>_exceptions.IndexOutOfRangeGetElement(array,index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = 7;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        //Arrange
        bool userLogedIn = true;
        string expected = "User logged in.";
        //Act
        string result =_exceptions.InvalidOperationPerformSecureOperation(userLogedIn);
        //Assert
        Assert.AreEqual(expected,result);
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool userLogedIn = false;
        //act && Assert
        Assert.That(()=>_exceptions.InvalidOperationPerformSecureOperation(userLogedIn), Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        //Arrange
        string input = "123";
        int expected = 123;
        //Act
        int result= _exceptions.FormatExceptionParseInt(input);
        //Assert
        Assert.AreEqual(expected,result);
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        //Arrange
        string input = "desi";
        //Act&& Assert
        Assert.That(()=> _exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["desi"] = 12,
            ["alex"]=15,
            ["georgi"]=1

        };
        string validKey = "desi";
        int expected = 12;
        //Act
        int result = _exceptions.KeyNotFoundFindValueByKey(input,validKey);
        //Assert
        Assert.AreEqual(expected,result);
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["desi"] = 12,
            ["alex"] = 15,
            ["georgi"] = 1

        };
        string validKey = "abc";
        
        //Act&&Assert
        Assert.That(()=>_exceptions.KeyNotFoundFindValueByKey(input,validKey), Throws.InstanceOf<KeyNotFoundException>());
       
        
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        //Arrange
        int a = 10;
        int b = 20;
        int expected = 30;
        //Act
        int result= _exceptions.OverflowAddNumbers(a,b);
        //Assert
        Assert.AreEqual(expected,result);
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = int.MaxValue;
        int b = 2;
        //Act&& Assert
        Assert.That(()=> _exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = int.MinValue;
        int b = -1;
        //Act&& Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int devident = 9;
        int divisor = 3;
        int expected = 3;
        //Act
        int result= _exceptions.DivideByZeroDivideNumbers(devident, divisor);
        //Assert
        Assert.AreEqual(expected,result);
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int devident = 9;
        int divisor = 0;
        //Act & &Assert
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(devident, divisor), Throws.InstanceOf<DivideByZeroException>());

    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] num = new int[] { 1, 2, 3, 4, };
        int index = 0;
        //Act
        int result=_exceptions.SumCollectionElements(num, index);
        //Assert
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[]? num =null;
        int index = 2;
        //Act && Assert
        Assert.That(()=> _exceptions.SumCollectionElements(num,index), Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] num = { 1, 2, 3, 4, };
        int index = 6;
        //Act && Assert
        Assert.That(() => _exceptions.SumCollectionElements(num, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["desi"]="12",
            ["georgi"] = "1",
            ["Peter"]= "22"
        };
        int expected = 12;
        string key = "desi";
        //Act
        int result = _exceptions.GetElementAsNumber(input, key);
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["desi"] = "12",
            ["georgi"] = "1",
            ["Peter"] = "22"
        };
        
        string key = "maria";
        //Act && Assert
        Assert.That(()=> _exceptions.GetElementAsNumber(input,key), Throws.InstanceOf<KeyNotFoundException>());

    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["desi"] = "peter",
            ["georgi"] = "1",
            ["Peter"] = "22"
        };

        string key = "desi";
        //Act && Assert
        Assert.That(() => _exceptions.GetElementAsNumber(input, key), Throws.InstanceOf<FormatException>());    
    }
}
