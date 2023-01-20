import React from "react";
import { routes } from "./routes";
import { Routes, Route, Navigate } from "react-router-dom";

const AppRouter = () => {
  return (
    <Routes>
      {routes.map((route) => (
        <Route
          element={route.component}
          path={route.path}
          exact={route.exact}
          key={route.path}
        />
      ))}
      {/* <Route path="*" element={<Error />} /> */}
      <Route path="/" element={<Navigate replace to="/home" />} />
      {/* TODO: Use after auth functionality */}
      {/* <Route path="/login" element={<Navigate replace to="/posts" />} /> */}
    </Routes>
  );
};

export default AppRouter;
