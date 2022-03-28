using FinancialChat.Domain.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialChat.Test.Helpers
{
    [TestClass]
    public class EncryptionHelperTest
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void Encrypt_WithEmptyStr_ReturnsEmpty(string str)
        {
            Assert.AreEqual(string.Empty, EncryptionHelper.EncryptBase64(str));
        }

        [TestMethod]
        [DataRow("2818125955")]
        [DataRow("2808400147")]
        [DataRow("1916922454")]
        public void Encrypt_NoEmptyStr_ReturnsEncryption(string str)
        {
            var result = EncryptionHelper.EncryptBase64(str);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void Decrypt_WithEmptyStr_ReturnsEmpty(string str)
        {
            Assert.AreEqual(string.Empty, EncryptionHelper.DecryptBase64(str));
        }

        [TestMethod]
        [DataRow("MjgxODEyNTk1NQ==")]
        [DataRow("MjgwODQwMDE0Nw==")]
        [DataRow("MTkxNjkyMjQ1NA==")]
        public void Decrypt_NoEmptyStr_ReturnsEncryption(string str)
        {
            var result = EncryptionHelper.DecryptBase64(str);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
        }
    }
}
