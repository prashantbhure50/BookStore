using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface IFeedBackBL
    {
        public bool AddFeedBack(FeedBackModle cart);
        public bool DeleteFeedBack(FeedBackModle id);
        public bool UpdateFeedBack(FeedBackModle cart);
    }
}
