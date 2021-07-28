using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IFeedBackRL
    {
        public bool AddFeedBack(FeedBackModle cart);
        public bool DeleteFeedBack(FeedBackModle id);
        public bool UpdateFeedBack(FeedBackModle cart);
    }
}
