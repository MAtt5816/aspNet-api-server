#!/bin/sh
set -e
shift
until mariadb -h "${DB_HOST}" -u "${DB_USER}" -p"${DB_PASS}" "${DB_NAME}" -e 'select 1'; do
  sleep 3
done
exec "$@"
