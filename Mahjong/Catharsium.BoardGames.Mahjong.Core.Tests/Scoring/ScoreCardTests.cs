using Catharsium.BoardGames.Mahjong.Interface.Entities.Scoring;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring;

[TestClass]
public class ScoreCardTests : TestFixture<ScoreCard>
{
    [TestMethod]
    public void AddCategory_NewCategory_IsAdded()
    {
        var category = "My category";
        var points = 123;

        this.Target.AddCategory(category, points);
        Assert.IsTrue(this.Target.Categories.ContainsKey(category));
        Assert.AreEqual(points, this.Target.Categories[category]);
    }


    [TestMethod]
    public void AddCategory_ExistingCategory_IsOverwritten()
    {
        var category = "My category";
        var points = 123;
        this.Target.AddCategory(category, points);

        var expected = 234;
        this.Target.AddCategory(category, expected);
        Assert.IsTrue(this.Target.Categories.ContainsKey(category));
        Assert.AreEqual(expected, this.Target.Categories[category]);
    }
}