import React, { useContext, useEffect, useState } from "react";
import useFetch from "../hooks/useFetch";
import { CurrentUserContext } from "./UserContext";

const Table = () => {
  const ID_INPUT_REGISTRATION = "regdate",
    ID_INPUT_ACTIVITY = "actdate";
  const apiUrl = "";
  const [{ response, isLoading }, doFetch] = useFetch(apiUrl);
  const [isEdit, setIsEdit] = useState(false);
  const [currentUserState, setCurrentUserState] = useContext(
    CurrentUserContext
  );

  useEffect(() => {
    if (!isEdit) {
      doFetch();
    }
  }, [doFetch, isEdit]);

  function formatDate(date) {
    return date.substring(0, 10);
  }

  function handleChangeDate(e) {
    if (!currentUserState.isEditing) {
      setIsEdit(true);
      setCurrentUserState((state) => ({
        ...state,
        isEditing: true,
        responseCache: JSON.parse(JSON.stringify(response)),
        response: response,
      }));
    }
    return e.target.value;
  }

  return (
    <section>
      <table>
        <thead>
          <tr>
            <th>UserID</th>
            <th>Date Registration</th>
            <th>Date Last Activity</th>
          </tr>
        </thead>
        <tbody>
          {!isLoading &&
            response &&
            response.map((user, i) => (
              <tr id={i} key={i}>
                <td>
                  <input readOnly type="text" value={user.id} />
                </td>
                <td>
                  <input
                    id={ID_INPUT_REGISTRATION + i}
                    onChange={(e) => (user.registeredAt = handleChangeDate(e))}
                    type="date"
                    defaultValue={formatDate(user.registeredAt)}
                  />
                </td>
                <td>
                  <input
                    id={ID_INPUT_ACTIVITY + i}
                    onChange={(e) => (user.activeAt = handleChangeDate(e))}
                    type="date"
                    defaultValue={formatDate(user.activeAt)}
                  />
                </td>
              </tr>
            ))}
        </tbody>
      </table>
    </section>
  );
};

export default Table;
