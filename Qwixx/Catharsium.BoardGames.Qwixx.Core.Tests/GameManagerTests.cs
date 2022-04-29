using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Qwixx.Core.Tests;

[TestClass]
public class GameManagerTests : TestFixture<GameManager>
{
    #region

    [TestMethod]
    public void CrossCell()
    {
        var actual = this.Target.CrossCell(0, 0, 0);
    }

    #endregion
}