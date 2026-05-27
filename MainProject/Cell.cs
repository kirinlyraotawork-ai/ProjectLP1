using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject
{
    /// <summary>
    /// Represents a single cell on the Blackout grid.
    /// </summary>
    public struct Cell
    {
        /// <summary>
        /// Check if the cell is on or not
        /// </summary>
        public bool IsOn { get; set; }


        /// <summary>
        /// Initializes the cell with a given true or false state.
        /// </summary>
        /// <param name="isOn">Initial on/off state.</param>
        public Cell(bool isOn)
        {
            IsOn = isOn;
        }

        /// <summary>Toggles the cell state between on and off.</summary>
        public void Toggle()
        {
            //if cell is on, turns it off.
            //if cell is off, turns it on.
            IsOn = !IsOn;
        }



    }
}