using NUnit.Framework;

namespace mutation_testing.Tests;

public class Tests
{

    [Test]
    public void Test1()
    {
        // Arrange
        var underTest = new Klasse();
        
        // Act
        var actual = underTest.Funksjon1();
        
        // Assert
        Assert.That(actual, Is.InstanceOf<int>());
    }
    
    // [Test]
    // public void Test1()
    // {
    //     // Arrange
    //     var underTest = new Klasse();
    //     
    //     // Act
    //     var actual = underTest.Funksjon1();
    //     
    //     // Assert
    //     Assert.That(actual, Is.EqualTo(2));
    // }
}