using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFWinformsClient.Model.Order
{
    public enum OrderStatus
    {
        /// <summary>
        /// The status of the order is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The order has been made but not processed.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// The orders has been paid.
        /// </summary>
        Paid = 2,

        /// <summary>
        /// The order has been declined.
        /// </summary>
        Declined = 3,

        /// <summary>
        /// The order has been shipped.
        /// </summary>
        Shipped = 4,

        /// <summary>
        /// The order has been authorized pending capture.
        /// </summary>
        Authorized = 5
    }
}
