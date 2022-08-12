export function enableDragDrop(componentInstance) {
    const containers = document.querySelectorAll('.task-card-container');
    if (containers.length === 0) return;
    const sortable = new Draggable.Sortable(containers, {
        draggable: '.draggable',
        delay: 0,
        distance: 50,
        mirror: { constrainDimensions: true }
    });
    sortable.on('sortable:stop', async evt => {
        if (componentInstance) {
            const data = evt.data;
            const taskCardId = parseInt(data.dragEvent.data.source.dataset.taskCardId);
            const taskListId = parseInt(data.newContainer.dataset.taskListId);
            await componentInstance.invokeMethodAsync(
                'HandleTaskCardMove', taskCardId, taskListId);
        } else {
            // There's no component instance. This is an error.
            throw new Error('Cannot notify component, because no component was supplied');
        }
    });
}