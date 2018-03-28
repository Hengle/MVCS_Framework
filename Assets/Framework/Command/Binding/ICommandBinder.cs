using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandBinder {

    bool single { get; set; }

    List<object> commands { get; set; }

    CommandEventType commandEventType { get; set; }

    ICommandBinder Bind(CommandEventType e);

    ICommandBinder To<T>();
}
