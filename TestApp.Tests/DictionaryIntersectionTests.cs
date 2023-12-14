using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstD = new Dictionary<string, int>();
        Dictionary<string, int> secondD = new();
        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstD, secondD);
        // Assert
        Assert.AreEqual(0, result.Count);

    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstD = new()
        {
            {"one", 1},
            {"two", 2}
        };
        Dictionary<string, int> secondD = new();
        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstD, secondD);
        // Assert
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange

        Dictionary<string, int> firstD = new()
        {
            {"one", 1},
            {"two", 2}
        };
        Dictionary<string, int> secondD = new()
        {
            {"three", 3},
            {"four", 4}
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstD, secondD);
        // Assert
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange

        Dictionary<string, int> firstD = new()
        {
            {"one", 1},
            {"two", 2}
        };
        Dictionary<string, int> secondD = new()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3}
        };
        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstD, secondD);
        // Assert
        Assert.AreEqual(2, result.Count);

        Assert.IsTrue(result.ContainsKey("one"));
        Assert.AreEqual(1, result["one"]);

        Assert.IsTrue(result.ContainsKey("two"));
        Assert.AreEqual(2, result["two"]);

        Assert.IsFalse(result.ContainsKey("three"));


    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange

        Dictionary<string, int> firstD = new()
        {
            {"one", 1},
            {"two", 2}
        };
        Dictionary<string, int> secondD = new()
        {
            {"one", 3},
            {"two", 4}
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstD, secondD);
        // Assert
        Assert.AreEqual(0, result.Count);
    }
}
