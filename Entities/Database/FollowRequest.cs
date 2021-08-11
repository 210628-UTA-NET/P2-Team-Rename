using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database {
    public class FollowRequest : Message {
        public override string Body { 
            get {
                return string.Format("{0} would like to follow you");
            }
        }

    }
}