using BusinessLayer.Interface;
using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedBackBL: IFeedBackBL
    {
        IFeedBackRL feedBackRl;
        public FeedBackBL(IFeedBackRL feedBackRl)
        {
            this.feedBackRl = feedBackRl;
        }
        public bool AddFeedBack(FeedBackModle modle)
        {
            return this.feedBackRl.AddFeedBack(modle);
        }
        public bool DeleteFeedBack(FeedBackModle modle)
        {
            return this.feedBackRl.DeleteFeedBack(modle);
        }
        public bool UpdateFeedBack(FeedBackModle modle)
        {
            return this.feedBackRl.UpdateFeedBack(modle);
        }
    }
}
