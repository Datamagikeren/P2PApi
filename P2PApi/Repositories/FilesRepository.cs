using P2PApi.Models;

using Microsoft.AspNetCore.Mvc;

namespace P2PApi.Repositories
{
    public class FilesRepository
    {
        public Dictionary<string, List<FileEndPoint>> _fileDictionary = new Dictionary<string, List<FileEndPoint>>();

        public IEnumerable<string> GetAllFileNames()
        {
            return _fileDictionary.Keys;
        }

        public IEnumerable<FileEndPoint>? GetAllFileEndPoints(string filename)
        {
            if (_fileDictionary.ContainsKey(filename)) return _fileDictionary[filename];

            return null;
        }

        public void AddEndpoint(string filename,[FromBody] FileEndPoint endPoint)
        {
            if (!_fileDictionary.ContainsKey(filename))
            {
                _fileDictionary.Add(filename, new List<FileEndPoint>());
            }
            _fileDictionary[filename].Add(endPoint);
        }

        public void Delete(string filename)
        {
            if (_fileDictionary.ContainsKey(filename))
            {
                _fileDictionary.Remove(filename);
            }
        }
    } //Godt arbejde :-)
}