using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace HP_MSA
{
    public partial class DiskInfo : ContentPage
    {
        public DiskInfo(HP_MSA.Unit item)
        {

            InitializeComponent();
            List<Unit> items = new List<Unit>();

            items.Add(new Unit()
            {
                updated = item.updated,
                systemName = item.systemName,
                serialNumber = item.serialNumber,
                productFamily = item.productFamily,
                model = item.model,
                osVersion = item.osVersion,
                cpgCount = item.cpgCount,
                nodeCount = item.nodeCount,
                diskCount = item.diskCount,
                vvCount = item.vvCount,
            });

            Disks.ItemsSource = items;
        }
    }
};

