import { useEffect, useRef, useState } from "react";
import {
  addTodosAPI,
  delTodoAPI,
  editTodosAPI,
  getTodoAPI,
} from "../../api/todos";
import "./index.css";

const Todos = () => {
  const [todos, setTodos] = useState([]);
  const [textBtn, setTextBtn] = useState("Them moi");
  const todoRef = useRef([]);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    setTodos(await getTodoAPI());
  };
  const delTodo = async (id) => {
    if (window.confirm("delete")) {
      await delTodoAPI(id);
      window.location.reload();
    }
  };
  const addOrEditTodo = async (event) => {
    event.preventDefault();
    const val = event.target[0].value;
    const id = event.target[1].value;
    if (id) {
      //update
      await editTodosAPI({
        name: val,
        id: id,
      });
      fetchData();
    } else {
      //create
      await addTodosAPI({
        name: val,
      });
      fetchData();
    }
  };
  const editTodo = (id) => {
    todoRef?.current.forEach((item) => {
      if (
        item.getAttribute("data-id") &&
        item.getAttribute("data-id") !== String(id)
      ) {
        item.className = "fas fa-edit";
      }
    });

    const inputName = document.getElementById("name");
    const inputId = document.getElementById("id");
    if (todoRef?.current[id].className == "fas fa-edit") {
      todoRef.current[id].className = "fas fa-user-edit";
      setTextBtn("Cap nhat");
      inputName.value = todoRef.current[id].getAttribute("data-name");
      inputId.value = id;
    } else if (todoRef?.current[id].className == "fas fa-user-edit") {
      todoRef.current[id].className = "fas fa-edit";
      setTextBtn("Them moi");
      inputName.value = "";
      inputId.value = null;
    }
  };

  return (
    <main id="todolist">
      <h1>
        Danh sách
        <span>Việc hôm nay không để ngày mai.</span>
      </h1>

      {todos ? (
        todos?.map((item, key) => (
          <li className="" key={key}>
            <span className="label">{item.name}</span>
            <div className="actions">
              <button
                className="btn-picto"
                type="button"
                onClick={() => editTodo(item.id)}
              >
                <i
                  className="fas fa-edit"
                  ref={(el) => (todoRef.current[item.id] = el)}
                  data-name={item.name}
                  data-id={item.id}
                />
              </button>
              <button
                className="btn-picto"
                type="button"
                aria-label="Delete"
                title="Delete"
                onClick={() => delTodo(item.id)}
              >
                <i className="fas fa-trash" />
              </button>
            </div>
          </li>
        ))
      ) : (
        <p>Danh sách nhiệm vụ trống.</p>
      )}
      {/* <li className="done">
          <span className="label">123</span>
          <div className="actions">
            <button className="btn-picto" type="button">
              <i className="fas fa-edit" />
            </button>
            <button className="btn-picto" type="button" aria-label="Delete" title="Delete">
              <i className="fas fa-trash" />
            </button>
          </div>
        </li>
        <li>
          <span className="label">123</span>
          <div className="actions">
            <button className="btn-picto" type="button">
              <i className="fas fa-user-edit" />
            </button>
            <button className="btn-picto" type="button" aria-label="Delete" title="Delete">
              <i className="fas fa-trash" />
            </button>
          </div>
        </li> */}

      <form onSubmit={addOrEditTodo}>
        <label>Thêm nhiệm vụ mới</label>
        <input type="text" name="name" id="name" />
        <input type="text" name="id" id="id" />
        <button type="submit">{textBtn}</button>
      </form>
    </main>
  );
};
export default Todos;
