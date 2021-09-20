using System;
using System.Collections.Generic;
using MySeries.Interfaces;

namespace MySeries.Classes {
    public class SerieRepository : IRepository<Series> {
        private List<Series> ListSeries = new List<Series>();
        public void Delete(int id) {
            ListSeries[id].Delete();
        }
        public Series GetID(int id) {
            return ListSeries[id];
        }
        public List<Series> List() {
            return ListSeries;
        }
        public int NextId() {
            return ListSeries.Count;
        }
        public void Insert(Series entity) {
            ListSeries.Add(entity);
        }
        public void Update(int id, Series entity) {
            ListSeries[id] = entity;
        }
    }
}