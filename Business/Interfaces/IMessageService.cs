﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IMessageService
    {
        Message? SendMessage(MessageSentDTO message);
    }
}
