namespace TDD_examples_1.implementations
{
    public interface IEncryptionManager
    {
        string encryptPassword(string plaintextPassword);
        bool loginUser(string username, string encryptedPassword);
    }
}