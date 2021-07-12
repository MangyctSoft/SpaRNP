import React, { useState, useContext, useEffect } from "react";
import useFetch from "../hooks/useFetch";
import { CurrentUserContext } from "./UserContext";

const EditingControls = () => {
  const ID_BUTTON_SAVE = "save",
    ID_BUTTON_CANCEL = "cancel";
  const apiUrl = "save";
  const [ , doFetch] = useFetch(apiUrl);
  const [isEdit, setIsEdit] = useState(false);
  const [currentUserState, setCurrentUserState] = useContext(
    CurrentUserContext
  );

  useEffect(() => {
    setIsEdit(currentUserState.isEditing);
  }, [setIsEdit, currentUserState]);

  function handleButtonSave(e) {
    e.preventDefault();
    console.log("currentUserStateresponse", currentUserState.response);
    if (currentUserState.response) {
      doFetch({
        method: "PUT",
        mode: "cors",
        headers: {
          Accept: "*/*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(currentUserState.response),
      });
    }
    setIsEdit(false);
    setCurrentUserState((state) => ({
      ...state,
      isEditing: false,
    }));
  }

  function handleButtonCancel(e) {
    setIsEdit(false);
    setCurrentUserState((state) => ({
      ...state,
      isEditing: false,
      response: [...currentUserState.responseCache],
    }));
  }

  return (
    <section>
      <button id={ID_BUTTON_SAVE} disabled={!isEdit} onClick={handleButtonSave}>
        SAVE
      </button>
      <button
        hidden
        id={ID_BUTTON_CANCEL}
        disabled={!isEdit}
        onClick={handleButtonCancel}
      >
        CANCEL
      </button>
    </section>
  );
};

export default EditingControls;
