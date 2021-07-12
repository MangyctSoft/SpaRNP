import React, { useState, useContext, useEffect } from "react";
import useFetch from "../hooks/useFetch";
import { CurrentUserContext } from "./UserContext";

const Calculate = () => {
  const apiUrl = "calculate";
  const [{ response, isLoading }, doFetch] = useFetch(apiUrl);
  const [isEdit, setIsEdit] = useState(false);
  const [isFetch, setIsFetch] = useState(false);
  const [currentUserState, setCurrentUserState] = useContext(
    CurrentUserContext
  );

  useEffect(() => {
    setIsEdit(currentUserState.isEditing);
  }, [setIsEdit, currentUserState]);

  useEffect(() => {
    if (!isLoading && currentUserState.isCalculating) {
      setIsFetch(false);
      setCurrentUserState((state) => ({
        ...state,
        isCalculating: false,
        barGraphData: response,
        render: true,
      }));
    }
  }, [isLoading, currentUserState, setCurrentUserState, response]);

  const handleClick = () => {
    if (!isFetch) {
      setIsFetch(true);
      setCurrentUserState((state) => ({
        ...state,
        isCalculating: true,
      }));
      doFetch();
    }
  };

  return (
    <section>
      <button disabled={isEdit} onClick={handleClick}>
        Calculate
      </button>
    </section>
  );
};

export default Calculate;
