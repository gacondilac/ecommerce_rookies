import axiosClient from "./axiosClient";

const END_POINT = {
  PRODUCT: "Products",
  CATEGORY: "Categories",
  USER: "User",
};
//product api
export const getProductAPI = () => {
  return axiosClient.get(END_POINT.PRODUCT);
};
export const delProductAPI = (id) => {
  return axiosClient.delete(END_POINT.PRODUCT + `/${id}`);
};
export const addProductAPI = (product) => {
  return axiosClient.post(END_POINT.PRODUCT, product);
};
export const editProductAPI = (product) => {
  return axiosClient.put(END_POINT.PRODUCT, product);
};
//category api
export const getCategoryAPI = () => {
  return axiosClient.get(END_POINT.CATEGORY);
};
export const delCategoryAPI = (id) => {
  return axiosClient.delete(END_POINT.CATEGORY + `/${id}`);
};
export const addCategoryAPI = (category) => {
  return axiosClient.post(END_POINT.CATEGORY, category);
};
export const editCategoryAPI = (category) => {
  return axiosClient.put(END_POINT.CATEGORY, category);
};
//user api
export const getUserAPI = () => {
  return axiosClient.get(END_POINT.USER);
};
