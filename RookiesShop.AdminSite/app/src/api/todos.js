import axiosClient from "./axiosClient";

const END_POINT = {
  TODOS: "Categories",
};
export const getTodoAPI = () => {
  return axiosClient.get(END_POINT.TODOS);
};
export const delTodoAPI = (id) => {
  return axiosClient.delete(END_POINT.TODOS + `/${id}`);
};
export const addTodosAPI = (todo) => {
  return axiosClient.post(END_POINT.TODOS, todo);
};
export const editTodosAPI = (todo) => {
  return axiosClient.put(END_POINT.TODOS, todo);
};
